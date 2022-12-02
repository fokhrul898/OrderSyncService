using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Delivery_Charge
    {
        public int id { get; set; }
        public long restaurant_id { get; set; }
        public decimal min_distance { get; set; }
        public decimal max_distance { get; set; }
        public decimal min_delivery_amount { get; set; }
        public decimal delivery_charge { get; set; }
        public bool delivery_type { get; set; }
        public string delivery_postcode { get; set; }
        public string area_code { get; set; }
    }
}
