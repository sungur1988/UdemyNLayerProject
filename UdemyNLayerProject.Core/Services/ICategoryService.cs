﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Entities;

namespace UdemyNLayerProject.Core.Services
{
    public interface ICategoryService : IService<Category>  
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
