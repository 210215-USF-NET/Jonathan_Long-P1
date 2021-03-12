using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class OrderCRVM
    {
        public int OrderID { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        public CustomerCRVM Customer { get; set; }
        public LocationCRVM Location { get; set; }

    }
}
