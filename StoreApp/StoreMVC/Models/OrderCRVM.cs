using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreModels;
namespace StoreMVC.Models
{
    public class OrderCRVM
    {
        public int OrderID { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }

    }
}
