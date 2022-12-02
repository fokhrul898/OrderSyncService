using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Restaurant_Cuisine
    {
        public Int64 id { get; set; }
        public string name { get; set; }
        public Int32 sort_order { get; set; }
    }
}
