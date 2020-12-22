using BookShop.DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dBContext;

        public ProductRepository(ApplicationDbContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public void Update(Product product)
        {
            var categoryFromDB = _dBContext.Products.FirstOrDefault(s=>s.Id == product.Id);

            if(product.ImageUrl != null)
            {
                categoryFromDB.ImageUrl = product.ImageUrl;
            }

            categoryFromDB.ISBN = product.ISBN;
            categoryFromDB.Price = product.Price;
            categoryFromDB.Price50 = product.Price50;
            categoryFromDB.ListPrice = product.ListPrice;
            categoryFromDB.Price100 = product.Price100;
            categoryFromDB.Title = product.Title;
            categoryFromDB.Description = product.Description;
            categoryFromDB.CategoryId = product.CategoryId;
            categoryFromDB.Author = product.Author;
            categoryFromDB.CoatingTypeId = product.CoatingTypeId;
        }
    }
}
