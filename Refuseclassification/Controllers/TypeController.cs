using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepository;

namespace Refuseclassification.Controllers
{
    /// <summary>
    /// 获取类型数据
    /// </summary>
    public class TypeController : BaseController
    {
        IRecordTypeRepository typeService;

        /// <summary>
        /// 类型数据
        /// </summary>
        /// <param name="typeService"></param>
        public TypeController(IRecordTypeRepository typeService)
        {
            this.typeService = typeService;
        }

        /// <summary>
        /// 获取所有类型:干垃圾、湿垃圾 etc.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<object> GetAll()
        {
            return typeService.GetList();
        }
    }
}