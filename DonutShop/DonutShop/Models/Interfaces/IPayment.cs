using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Interfaces
{
    public interface IPayment
    {
        string Run(decimal total, int creditCardID, Address address);
    }
}
