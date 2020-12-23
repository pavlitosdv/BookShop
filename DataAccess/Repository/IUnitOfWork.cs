using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        ICompanyRepository Company { get; }
        ICoatingTypeRepository CoatingType { get; }
        IProductRepository Product { get; }

        IStoreProcedure StoreProcedure { get; }

        void Save();
    }
}
