﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.IRepository
{
  public interface ICategoryRepository : IRepositoryAsync<Category>
    {
        void Update(Category category);
    }
}
