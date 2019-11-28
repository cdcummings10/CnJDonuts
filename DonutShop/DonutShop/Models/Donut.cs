using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models
{
    public class Donut
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Boozey { get; set; }
        public bool CreamFilled { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }

        //Navigation properties
        public CartItem CartItem { get; set; }

    }
}
