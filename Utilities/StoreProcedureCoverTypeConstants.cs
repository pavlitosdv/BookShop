﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
   public class StoreProcedureCoverTypeConstants
    {
        public const string Proc_CoverType_Create = "usp_CreateCoatingType";
        public const string Proc_CoverType_Get = "usp_GetCoatingType";
        public const string Proc_CoverType_GetAll = "usp_GetCoatingTypes";
        public const string Proc_CoverType_Update = "usp_UpdateCoatingType";
        public const string Proc_CoverType_Delete = "usp_DeleteCoatingType";

        public const string Role_User_Individual = "Individual Customer";
        public const string Role_User_Company = "Company Customer";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";

        public const string ssShoppingCart = "Shoping Cart Session";

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
        public const string PaymentStatusRejected = "Rejected";

        public static double GetPriceBasedOnQuantity(double quantity, double price, double price50, double price100)
        {
            if (quantity < 50)
            {
                return price;
            }
            else
            {
                if (quantity < 100)
                {
                    return price50;
                }
                else
                {
                    return price100;
                }
            }
        }

        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}
