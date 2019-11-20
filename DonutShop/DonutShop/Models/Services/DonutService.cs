using DonutShop.Data;
using DonutShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Services
{
    public class DonutService : IInventory<Donut>
    {
        private InventoryDbContext _context;
        public DonutService(InventoryDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Takes in a donut object and adds it to the database.
        /// </summary>
        /// <param name="donut">Takes in a donut object.</param>
        /// <returns></returns>
        public async Task Create(Donut donut)
        {
            await _context.AddAsync(donut);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Finds a Donut object by ID and removes it from the database.
        /// </summary>
        /// <param name="id">Takes in the ID of the donut needed to be deleted.</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            Donut donut = await GetByID(id);
            _context.Remove(donut);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Gets all donuts saved in the database.
        /// </summary>
        /// <returns>Returns the donuts as a List.</returns>
        public async Task<IEnumerable<Donut>> GetAll()
        {
            return await _context.Donuts.ToListAsync();
        }
        /// <summary>
        /// Gets a specific donut by ID and returns it.
        /// </summary>
        /// <param name="id">Takes in the donut's ID</param>
        /// <returns>Returns the donut selected by ID.</returns>
        public async Task<Donut> GetByID(int id)
        {
            return await _context.Donuts.FirstOrDefaultAsync(x => x.ID == id);
        }
        /// <summary>
        /// Takes in a donut and updates it.
        /// </summary>
        /// <param name="donut">Takes in a donut object.</param>
        /// <returns></returns>
        public async Task Update(Donut donut)
        {
            _context.Update(donut);
            await _context.SaveChangesAsync();
        }
    }
}
