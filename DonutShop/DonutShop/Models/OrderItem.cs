using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models
{
    public class OrderItem
    {
        public int OrderID { get; set; }
        public int DonutID { get; set; }
        public int Quantity { get; set; }


        //navigation properties
        public Order Order { get; set; }
        public Donut Donut { get; set; }
    }
}
