using DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StoreProcedureCoverTypeConstants.Role_Admin)]
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
        public async Task<IActionResult> AddOrUpdate(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                //create Section
                return View(category);
            }

            // edit - update section               
            category = await _unitOfWork.Category.GetAsync(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                   await _unitOfWork.Category.AddAsync(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index)); // insted writing with magic string "Index" 
                                                        //we use nameof(Index)
            }
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getall = await _unitOfWork.Category.GetAllAsync();

            return Json(new { data = getall });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _unitOfWork.Category.GetAsync(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Category not found for deletion" });
            }
            await _unitOfWork.Category.RemoveAsync(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

    }
}
