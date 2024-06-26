﻿using BusinessObject;
using Service.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<Category> GetCateName(string name);
    }
}
