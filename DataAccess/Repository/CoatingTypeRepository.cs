using BookShop.DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class CoatingTypeRepository : Repository<CoatingType>, ICoatingTypeRepository
    {
        private readonly ApplicationDbContext _dBContext;

        public CoatingTypeRepository(ApplicationDbContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public void Update(CoatingType coatingType)
        {
            var categoryFromDB = _dBContext.CoatingTypes.FirstOrDefault(s=>s.Id == coatingType.Id);

            if(categoryFromDB != null)
            {
                categoryFromDB.Name = coatingType.Name;
            }
        }
    }
}
