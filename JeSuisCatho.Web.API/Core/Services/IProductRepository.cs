﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models.Shop;

namespace JeSuisCatho.Web.API.Core.Services
{
    public interface IProductRepository
    {

        Task<Product> GetProduct(int id, bool includeRelated = true);

        Task<Product> GetProductBySeason(bool productOfSeason, bool includeRelated = true);
        void Add(Product product);
        void Remove(Product product);
    }
}