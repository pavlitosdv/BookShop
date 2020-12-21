using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        ICoatingTypeRepository CoatingType { get; }

        IStoreProcedure StoreProcedure { get; }

        void Save();
    }
}
