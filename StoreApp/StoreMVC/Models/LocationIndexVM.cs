using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public class LocationIndexVM
    {
        [DisplayName("Store Code")]
        public int LocationID { get; set; }
        [DisplayName("Store Name")]
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
    }
}
