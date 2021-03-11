using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class StoredProductsQuantity
    {
        public List<ProductCRVM> Product2BeBought { get; set; }
        public List<int> Quantity2BeBought { get; set; }

        public void ClearStoredProductsQuantity()
        {
            Product2BeBought.Clear();
            Quantity2BeBought.Clear();
        }
    }
}
