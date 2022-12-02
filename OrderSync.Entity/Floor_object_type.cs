using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Floor_object_type
    {
        public int id { get; set; }
        public string object_type { get; set; }
        public Boolean accept_seat { get; set; }
        public string color { get; set; }
    }
}
