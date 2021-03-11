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
    /// Data logic for our locations
    /// </summary>
    public class LocationRepoDB : ILocationRepository
    {
        private readonly StoreDBContext _context;
        public LocationRepoDB(StoreDBContext context)
        {
            _context = context;
        }

        public Location GetLocationByName(string locationName)
        {
            return _context.Locations.AsNoTracking().Select(location => location).ToList().FirstOrDefault(loc => loc.LocationName == locationName);
        }

        public List<Location> GetLocations()
        {
            return _context.Locations.AsNoTracking().Select(location => location).ToList();
        }

        public Location GetSpecificLocation(int storeCode)
        {
            return _context.Locations.AsNoTracking().Select(location => location).ToList().FirstOrDefault(loc => loc.LocationID == storeCode);
        }
    }
}
