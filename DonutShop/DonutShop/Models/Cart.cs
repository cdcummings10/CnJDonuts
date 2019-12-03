using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string UserEmail { get; set; }

        //Navigation Properties
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
