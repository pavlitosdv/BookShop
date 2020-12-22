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
    public class CoatingTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoatingTypeController(IUnitOfWork unitOfWork)
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
            CoatingType coatingType = new CoatingType();
            if (id == null)
            {
                //create Section
                return View(coatingType);
            }

            // edit - update section               
            coatingType = _unitOfWork.CoatingType.GetById(id.GetValueOrDefault());
            if (coatingType == null)
            {
                return NotFound();
            }
            return View(coatingType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(CoatingType coatingType)
        {
            if (ModelState.IsValid)
            {
                if (coatingType.Id == 0)
                {
                    _unitOfWork.CoatingType.Add(coatingType);
                }
                else
                {
                    _unitOfWork.CoatingType.Update(coatingType);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index)); // insted writing with magic string "Index" 
                                                        //we use nameof(Index)
            }
            return View(coatingType);
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var getall = _unitOfWork.CoatingType.GetAll();

            return Json(new { data = getall });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.CoatingType.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "CoatingType not found for deletion" });
            }
            _unitOfWork.CoatingType.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

    }
}
