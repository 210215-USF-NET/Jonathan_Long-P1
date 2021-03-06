using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ILocationRepository
    {
         List<Location> GetLocations();
         Location GetSpecificLocation(int storeCode);
        Location GetLocationByName(string locationName);

    }
}