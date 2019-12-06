using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.ViewModels
{
    public class AdminUpdateViewModel
    {
        public Donut Donut { get; set; }
        public IFormFile Image { get; set; }
    }
}
