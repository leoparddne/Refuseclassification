using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCLUtility;
using Common;
using Common.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;

namespace Refuseclassification.Controllers
{
    /// <summary>
    /// 获取记录数据
    /// </summary>
    public class RecordController : BaseController
    {
        IRecordTypeRepository typeService;
        IRecordRepository recordService;
        IUnitOfWork db;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeService"></param>
        /// <param name="recordService"></param>
        /// <param name="db"></param>
        public RecordController(IRecordTypeRepository typeService, IRecordRepository recordService, IUnitOfWork db)
        {
            this.typeService = typeService;
            this.recordService = recordService;
            this.db = db;
        }

        /// <summary>
        /// 获取所有垃圾分类的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Repository.Entity.record> GetAll()
        {
            return recordService.GetList(f=>f.state==ValidState.Valid);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPage(int page,int pageSize)
        {
            CommonUtility.CheckPage(page, pageSize);
            var data = GetAll();
            var count = data.Count();
            data = data.Skip((page - 1) * pageSize).Take(pageSize);
            return new ObjectResult(new RetPagedData(data, page, pageSize, count));
        }
        /// <summary>
        /// 根据类型获取分页数据
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPageByType(int type, int page, int pageSize)
        {
            CommonUtility.CheckPage(page, pageSize);
            var data = GetAll();
            if (type > 0)
            {
                data = data.Where(f => f.type == type);
            }
            var count = data.Count();
            data = data.Skip((page - 1) * pageSize).Take(pageSize);
            return new ObjectResult(new RetPagedData(data, page, pageSize, count));
        }
        
        /// <summary>
        /// 查询指定的物品的分类
        /// </summary>
        /// <param name="name">需要搜索的关键字,支持模糊搜索</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Search(string name)
        {
            var data =recordService.Get(f => f.name.Contains(name)&&f.state==ValidState.Valid);
            if(data==null)
            {
                throw new RequestException(RetCode.NOData);
            }
            var result=data.AutoMapping<ResponseRecord>();
            var typeData= typeService.Get(f => f.id == result.type && f.state == ValidState.Valid);
            if (typeData == null)
            {
                throw new RequestException(RetCode.NOData);
            }
            result.typeName = typeData.name;
            //更新搜索数据
            try
            {
                data.count++;
                recordService.Update(data);
                db.Commit();
            }
            catch
            {

            }
            return new ObjectResult(result);
        }
        /// <summary>
        /// 获取搜索热度最高的20条
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPopData()
        {
            var data=recordService.GetList(f => f.state == ValidState.Valid).OrderByDescending(f => f.count).Take(20);
            var result = new List<ResponseRecord>();
            foreach (var item in data)
            {
                var tmp = item.AutoMapping<ResponseRecord>();
                var typeData = typeService.Get(f => f.id == tmp.type && f.state == ValidState.Valid);
                if (typeData == null)
                {
                    throw new RequestException(RetCode.NOData);
                }
                tmp.typeName = typeData.name;
                result.Add(tmp);
            }
            return new ObjectResult(result);
        }
    }
}