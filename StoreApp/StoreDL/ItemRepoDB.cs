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
        //Add an item to the DB
        public Item AddItem(Item newItem)
        {
            throw new NotImplementedException();
        }
        //Return a specific item
        public Item GetItemByID(int itemID)
        {
            var queryItem =
            (from item in _context.Items
             where item.ItemID == itemID
             select item).ToList().FirstOrDefault();
            if(queryItem == null)
            {
                return null;
            }
            queryItem.Product = _context.Products.Find(queryItem.ProductID);
            queryItem.Location = _context.Locations.Find(queryItem.LocationID);
            return queryItem;
        }
        //Return all items
        public List<Item> GetItems()
        {
            return _context.Items.Include("Products").AsNoTracking().Include("Locations").AsNoTracking().Select(item => item).ToList();
        }
        //Return items for a specific location
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
        //Update quantity for an item object
        public void UpdateItem(Item item2BUpdated)
        {
            Item actualItem2BUpdated = new Item();
            actualItem2BUpdated.ItemID = item2BUpdated.ItemID;
            actualItem2BUpdated.Quantity = item2BUpdated.Quantity;
            actualItem2BUpdated.LocationID = item2BUpdated.LocationID;
            actualItem2BUpdated.ProductID = item2BUpdated.ProductID;
            _context.Entry(item2BUpdated).CurrentValues.SetValues(actualItem2BUpdated);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}
