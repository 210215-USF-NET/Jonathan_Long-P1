using StoreModels;

namespace StoreMVC.Models
{
    public interface IMapper
    {
        CustomerIndexVM Cast2CustomerIndexVM(Customer customer2BCasted);
    }
}