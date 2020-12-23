using BookShop.DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _dBContext;

        public CompanyRepository(ApplicationDbContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public void Update(Company company)
        {
            _dBContext.Update(company);
        }
    }
}
