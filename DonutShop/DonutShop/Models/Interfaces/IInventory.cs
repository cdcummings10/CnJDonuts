using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models.Interfaces
{
    public interface IInventory<T>
    {
        /// <summary>
        /// Takes in an item object and adds it to the database.
        /// </summary>
        /// <param name="item">Takes in an item object.</param>
        /// <returns></returns>
        Task Create(T item);
        /// <summary>
        /// Gets all of a table and returns it as an IEnumerable.
        /// </summary>
        /// <returns>Returns an IEnumerable of objects from the table.</returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Gets an item from the database based on the ID.
        /// </summary>
        /// <param name="id">Takes in an ID as an integer.</param>
        /// <returns>Returns the item found by ID.</returns>
        Task<T> GetByID(int id);
        /// <summary>
        /// Takes in an item and updates it in the database.
        /// </summary>
        /// <param name="item">Takes in an item object.</param>
        /// <returns></returns>
        Task Update(T item);
        /// <summary>
        /// Finds an element by ID and removes it from the database.
        /// </summary>
        /// <param name="id">Takes in an item's ID.</param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
