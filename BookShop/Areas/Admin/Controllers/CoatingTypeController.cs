using Dapper;
using DataAccess.Repository;
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
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);

            coatingType = _unitOfWork.StoreProcedure.OneRecord<CoatingType>(StoreProcedureCoverTypeConstants.Proc_CoverType_Get, parameter);
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
                var parameter = new DynamicParameters();
                parameter.Add("@Name", coatingType.Name);

                if (coatingType.Id == 0)
                {
                    _unitOfWork.StoreProcedure.Execute(StoreProcedureCoverTypeConstants.Proc_CoverType_Create, parameter);
                }
                else
                {
                    parameter.Add("@Id", coatingType.Id);
                    _unitOfWork.StoreProcedure.Execute(StoreProcedureCoverTypeConstants.Proc_CoverType_Update, parameter);
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
            var getall = _unitOfWork.StoreProcedure.List<CoatingType>(StoreProcedureCoverTypeConstants.Proc_CoverType_GetAll, null);

            return Json(new { data = getall });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);

            var objFromDb = _unitOfWork.StoreProcedure.OneRecord<CoatingType>(StoreProcedureCoverTypeConstants.Proc_CoverType_Get,parameter);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "CoatingType not found for deletion" });
            }
            _unitOfWork.StoreProcedure.Execute(StoreProcedureCoverTypeConstants.Proc_CoverType_Delete, parameter);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }



        #region Old CRUD operation code using IUnit of work (entity framework mode)

        //public IActionResult Index()
        //{
        //    return View();
        //}

        ////this will be used either to create a new entity or to update an existing one
        //public IActionResult AddOrUpdate(int? id)
        //{
        //    CoatingType coatingType = new CoatingType();
        //    if (id == null)
        //    {
        //        //create Section
        //        return View(coatingType);
        //    }

        //    // edit - update section               
        //    coatingType = _unitOfWork.CoatingType.GetById(id.GetValueOrDefault());
        //    if (coatingType == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(coatingType);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddOrUpdate(CoatingType coatingType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (coatingType.Id == 0)
        //        {
        //            _unitOfWork.CoatingType.Add(coatingType);
        //        }
        //        else
        //        {
        //            _unitOfWork.CoatingType.Update(coatingType);
        //        }
        //        _unitOfWork.Save();
        //        return RedirectToAction(nameof(Index)); // insted writing with magic string "Index" 
        //                                                //we use nameof(Index)
        //    }
        //    return View(coatingType);
        //}



        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var getall = _unitOfWork.CoatingType.GetAll();

        //    return Json(new { data = getall });
        //}

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var objFromDb = _unitOfWork.CoatingType.GetById(id);
        //    if (objFromDb == null)
        //    {
        //        return Json(new { success = false, message = "CoatingType not found for deletion" });
        //    }
        //    _unitOfWork.CoatingType.Remove(objFromDb);
        //    _unitOfWork.Save();
        //    return Json(new { success = true, message = "Delete Successful" });
        //}

        #endregion

    }
}
