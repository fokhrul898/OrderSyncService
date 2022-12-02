using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class OnlineCardPaymentOrder
    {
        public string order_id { get; set; }
        public string restaurant_id { get; set; }
        public string restaurant_name { get; set; }
        public string delivery_time { get; set; }
        public string order_time { get; set; }
        public string order_policy { get; set; }
        public string payment_method { get; set; }
        public decimal discount_amount { get; set; }
        public decimal service_charge { get; set; }
        public decimal delivery_charge { get; set; }
        public decimal sub_total { get; set; }
        public decimal grand_total { get; set; }
        public string platform { get; set; }
        public List<order_item> order_items { get; set; }
        public string payment_status { get; set; }
        public bool status { get; set; }
        public customer_info customer_info { get; set; }
        public string order_date { get; set; }
        public string special_instruction { get; set; }
    }
}
