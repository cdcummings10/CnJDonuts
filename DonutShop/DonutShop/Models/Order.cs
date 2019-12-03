using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string Email { get; set; }

        //nav property
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
