using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class LocationCRVM
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
    }
}
