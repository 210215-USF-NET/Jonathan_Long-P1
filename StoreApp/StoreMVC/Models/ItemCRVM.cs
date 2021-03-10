using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class ItemCRVM
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int LocationID { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string LocationName { get; set; }
    }
}
