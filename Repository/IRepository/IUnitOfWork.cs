using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.IRepository
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
