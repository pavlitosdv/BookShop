﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.IRepository
{
  public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
    }
}
