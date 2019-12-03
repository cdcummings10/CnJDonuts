using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models
{
    public class Email
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
