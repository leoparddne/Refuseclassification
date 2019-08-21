using Common;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.IRepository
{
    public interface IRepository
    {

    }
    public interface IRepositoryBase<T>: IRepository where T : EntityBase
    {
        bool Exist(Func<T, bool> lambda);
        void Add(T obj);
        void Del(T obj);
        void DelRange(IEnumerable<T> list);
        void Update(T obj);
        void UpdateRange(IEnumerable<T> list);
        T Get(Func<T, bool> lambda);
        T Get(object key);
        IEnumerable<T> GetList();
        IEnumerable<T> GetList(Func<T, bool> lambda);
        RetPagedData GetListByPage(Func<T, bool> lambda, int page, int pageSize);
        IEnumerable<T> GetListByPage(Func<T, bool> lambda, int page, int pageSize,out int total);
        int Commit();
    }
}
