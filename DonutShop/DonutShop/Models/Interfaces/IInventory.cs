using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Interfaces
{
    public interface IInventory
    {
        Task Create(Donut donut);
        Task<IEnumerable<Donut>> GetAll();
        Task<Donut> GetByID(int id);
        Task Update(Donut donut);
        Task Delete(int id);
    }
}
