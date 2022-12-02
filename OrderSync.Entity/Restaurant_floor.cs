using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Restaurant_floor
    {
        public int id { get; set; }
        public string floor_name { get; set; }
        public long restaurant_id { get; set; }
    }
}
