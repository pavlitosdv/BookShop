using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        //this will be used either to create a new entity or to update an existing one
        public IActionResult AddOrUpdate(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                //create Section
                return View(category);
            }

            // edit - update section               
            category = _unitOfWork.Category.GetById(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var getall = _unitOfWork.Category.GetAll();

            return Json(new { data = getall });
        }
    }
}
