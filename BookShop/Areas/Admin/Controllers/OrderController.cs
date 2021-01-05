using DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utilities;

namespace BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StoreProcedureCoverTypeConstants.Role_Admin)]
    public class OrderController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        //[BindProperty]
        //public OrderDetailsVM OrderVM { get; set; }

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }




        #region API CALLS
        [HttpGet]
        public IActionResult GetOrderList(string status)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            IEnumerable<OrderHeader> orderHeaderList;

            if (User.IsInRole(StoreProcedureCoverTypeConstants.Role_Admin) || User.IsInRole(StoreProcedureCoverTypeConstants.Role_Employee))
            {
                orderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            }
            else
            {
                orderHeaderList = _unitOfWork.OrderHeader.GetAll(
                                        u => u.ApplicationUserId == claim.Value,
                                        includeProperties: "ApplicationUser");
            }

            switch (status)
            {
                case "pending":
                    orderHeaderList = orderHeaderList.Where(o => o.PaymentStatus == StoreProcedureCoverTypeConstants.PaymentStatusDelayedPayment);
                    break;
                case "inprocess":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == StoreProcedureCoverTypeConstants.StatusApproved ||
                                                            o.OrderStatus == StoreProcedureCoverTypeConstants.StatusInProcess ||
                                                            o.OrderStatus == StoreProcedureCoverTypeConstants.StatusPending);
                    break;
                case "completed":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == StoreProcedureCoverTypeConstants.StatusShipped);
                    break;
                case "rejected":
                    orderHeaderList = orderHeaderList.Where(o => o.OrderStatus == StoreProcedureCoverTypeConstants.StatusCancelled ||
                                                            o.OrderStatus == StoreProcedureCoverTypeConstants.StatusRefunded ||
                                                            o.OrderStatus == StoreProcedureCoverTypeConstants.PaymentStatusRejected);
                    break;
                default:
                    break;
            }

            return Json(new { data = orderHeaderList });
        }
        #endregion

    }
}
