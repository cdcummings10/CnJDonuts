using DonutShop.Data;
using DonutShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Services
{
    public class DonutService : IInventory
    {
        private InventoryDbContext _context;
        public DonutService(InventoryDbContext context)
        {
            _context = context;
        }
        public async Task Create(Donut donut)
        {
            await _context.AddAsync(donut);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Donut donut = await GetByID(id);
            _context.Remove(donut);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Donut>> GetAll()
        {
            return await _context.Donuts.ToListAsync();
        }

        public async Task<Donut> GetByID(int id)
        {
            return await _context.Donuts.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task Update(Donut donut)
        {
            _context.Update(donut);
            await _context.SaveChangesAsync();
        }
    }
}
