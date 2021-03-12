using StoreModels;

namespace StoreMVC.Models
{
    public interface IMapper
    {
        CustomerIndexVM Cast2CustomerIndexVM(Customer customer2BCasted);
        Customer Cast2Customer(CustomerCRVM customer2BCasted);
        CustomerCRVM Cast2CustomerCRVM(Customer customer2BCasted);
        LocationIndexVM Cast2LocationIndexVM(Location location);
        ItemCRVM Cast2ItemCRVM(Item item2BCasted);
        ProductCRVM Cast2ProductCRVM(Product item2BCasted);
        LocationCRVM Cast2LocationCRVM(Location item2BCasted);
        Order Cast2Order(OrderCRVM item2BCasted);
        CustomerShopModel Cast2CustomerShopModel(Customer item2BCasted);
    }
}