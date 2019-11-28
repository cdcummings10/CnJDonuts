using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public int DonutID { get; set; }
        public int Quantity { get; set; }


        //navigation properties
        public Cart Cart { get; set; }
        public Donut Donut { get; set; }
    }
}
