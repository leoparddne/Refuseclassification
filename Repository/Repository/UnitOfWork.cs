using Repository.DbContexts;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly CommonContext context;

        public UnitOfWork(CommonContext context)
        {
            this.context = context;
        }

        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
