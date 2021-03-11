using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class StoredProductsQuantity
    {

        public ProductCRVM Product2BeBought { get; set; }
        public int Quantity2BeBought { get; set; }
        public static List<StoredProductsQuantity> storedProductsQuantity = new List<StoredProductsQuantity>();

        public void ClearStoredProductsQuantity()
        {
            storedProductsQuantity.Clear();
        }
    }
}
