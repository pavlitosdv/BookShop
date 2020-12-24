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
    }
}
