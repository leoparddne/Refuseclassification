using Common;
using Microsoft.EntityFrameworkCore;
using Repository.DbContexts;
using Repository.Entity;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly DbSet<T> dbSet;
        protected readonly CommonContext context;
        public RepositoryBase(CommonContext context)
        {
            this.context = context;
            dbSet=context.Set<T>();
        }
        public bool Exist(Func<T, bool> lambda)
        {
            return dbSet.AsNoTracking().Count(lambda) > 0;
        }

        public void Add(T obj)
        {
            dbSet.Add(obj);
        }

        public void Del(T obj)
        {
            dbSet.Remove(obj);
        }

        public void DelRange(IEnumerable<T> list)
        {
            dbSet.RemoveRange(list);
        }

        public T Get(Func<T, bool> lambda)
        {
            return  dbSet.FirstOrDefault(lambda);
        }
        public T Get(object key)
        {
            return dbSet.Find(key);
        }
        public IEnumerable<T> GetList()
        {
            return dbSet.AsEnumerable();
        }

        public IEnumerable<T> GetList(Func<T, bool> lambda)
        {
            return dbSet.Where(lambda);
        }

        public RetPagedData GetListByPage(Func<T, bool> lambda, int page, int pageSize)
        {
            var data = GetList(lambda);
            var allCount = data.Count();

            var result = data.Skip((page - 1) * pageSize).Take(pageSize);
            
            return new RetPagedData(result, page, pageSize, allCount);
        }
        public IEnumerable<T> GetListByPage(Func<T, bool> lambda, int page, int pageSize, out int total)
        {
            var data = GetList(lambda);
            total = data.Count();

            return data.Skip((page - 1) * pageSize).Take(pageSize);
        }
        public void Update(T obj)
        {
            dbSet.Update(obj);
        }

        public void UpdateRange(IEnumerable<T> list)
        {
            dbSet.UpdateRange(list);
        }

        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
