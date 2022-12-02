using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Offer_Discount
    {
        public byte id { get; set; }
        public string order_policy { get; set; }
        public string payment_method { get; set; }
        public Decimal eligible_amount { get; set; }
        public Decimal discount_amount { get; set; }
        public decimal dine_in_discount_amount { get; set; }
        public bool enable_waiting { get; set; }
        public bool enable_collection { get; set; }
        public bool enable_delivery { get; set; }
        public bool enable_table { get; set; }
        public string available_days { get; set; }
        public string available_dine_in_days { get; set; }

    }
}
