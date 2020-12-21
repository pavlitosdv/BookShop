﻿using BookShop.DataAccess.Data;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbcontext;

        public ICategoryRepository Category { get; private set; }
        public IStoreProcedure StoreProcedure { get; private set; }

        public UnitOfWork(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            Category = new CategoryRepository(dbcontext);
            StoreProcedure = new StoreProcedureCalls(dbcontext);
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
