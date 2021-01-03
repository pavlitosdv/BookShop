using BookShop.DataAccess.Data;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbcontext;

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public ICoatingTypeRepository CoatingType { get; private set; }
        public IProductRepository Product { get; private set; }
        public IStoreProcedure StoreProcedure { get; private set; }

        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderDetailsRepository OrderDetails { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }

        public UnitOfWork(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            ApplicationUser = new ApplicationUserRepository(dbcontext);
            Category = new CategoryRepository(dbcontext);
            CoatingType = new CoatingTypeRepository(dbcontext);
            Company = new CompanyRepository(dbcontext);
            Product = new ProductRepository(dbcontext);
            StoreProcedure = new StoreProcedureCalls(dbcontext);
            OrderDetails = new OrderDetailsRepository(dbcontext);
            OrderHeader = new OrderHeaderRepository(dbcontext);
            ShoppingCart = new ShoppingCartRepository(dbcontext);
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}
