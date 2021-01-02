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
    [Authorize(Roles = StoreProcedureCoverTypeConstants.Role_Admin + "," + StoreProcedureCoverTypeConstants.Role_Employee)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
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
            Company company = new Company();
            if (id == null)
            {
                //create Section
                return View(company);
            }

            // edit - update section               
            company = _unitOfWork.Company.GetById(id.GetValueOrDefault());
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index)); // insted writing with magic string "Index" 
                                                        //we use nameof(Index)
            }
            return View(company);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var getall = _unitOfWork.Company.GetAll();

            return Json(new { data = getall });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Company.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Company not found for deletion" });
            }
            _unitOfWork.Company.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

    }
}
