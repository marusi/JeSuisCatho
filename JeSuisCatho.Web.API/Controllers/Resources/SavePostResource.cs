﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Models;

namespace JeSuisCatho.Web.API.Controllers.Resources
{
    public class SavePostResource
    {
        public int Id { get; set; }

        public int NewsCategoryId { get; set; }
        public string Title { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }

        public DateTime Created { get; set; }
    }
}
