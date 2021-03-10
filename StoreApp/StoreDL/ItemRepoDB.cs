using Microsoft.EntityFrameworkCore;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    /// <summary>
    /// Data lata for items(inventory)
    /// </summary>
    public class ItemRepoDB : IItemRepository
    {
        private readonly StoreDBContext _context;
        public ItemRepoDB(StoreDBContext context)
        {
            _context = context;
        }

        public Item AddItem(Item newItem)
        {
            throw new NotImplementedException();
        }

        public Item GetItemByID(int itemID)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetItems()
        {
            return _context.Items.Include("Products").AsNoTracking().Include("Locations").AsNoTracking().Select(item => item).ToList();
        }

        public List<Item> GetItemsByLocation(int locationID)
        {
            return _context.Items
                .Include("Product")
                .AsNoTracking()
                .Include("Location")
                .AsNoTracking()
                .Select(item => item)
                .ToList()
                .FindAll(item => item.Location.LocationID == locationID);
        }

        public void UpdateItem(Item item2BUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
