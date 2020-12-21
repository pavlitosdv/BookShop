﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.IRepository
{
  public interface ICoatingTypeRepository : IRepository<CoatingType>
    {
        void Update(CoatingType coatingType);
    }
}
