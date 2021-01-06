using BookShop.DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class CategoryRepository : RepositoryAsync<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dBContext;

        public CategoryRepository(ApplicationDbContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public void Update(Category category)
        {
            var categoryFromDB = _dBContext.Categories.FirstOrDefault(s=>s.Id == category.Id);

            if(categoryFromDB != null)
            {
                categoryFromDB.Name = category.Name;
            }
        }
    }
}
