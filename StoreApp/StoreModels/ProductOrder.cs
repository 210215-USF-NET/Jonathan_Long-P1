using System.ComponentModel.DataAnnotations;

namespace StoreModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductOrder
    {
        //Properties
        [Key]
        public int ProductOrderID { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public Order Order { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
    }
}