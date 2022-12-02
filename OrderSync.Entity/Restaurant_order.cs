using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Restaurant_order
    {
        public string id { get; set; }
        public string _id { get; set; }
        public long server_id { get; set; }
        public bool status { get; set; }
        public int restaurant_order_policy_id { get; set; }
        public decimal total_amount { get; set; }
        public decimal grand_total { get; set; }
        public decimal discount_amount { get; set; }
        public decimal discount_percent { get; set; }
        public decimal discount_percent_amount { get; set; }
        public decimal delivery_percent { get; set; }
        public decimal delivery_charge { get; set; }
        public decimal service_charge { get; set; }
        public decimal cash_payment { get; set; }
        public decimal card_payment { get; set; }
        public decimal voucher_payment { get; set; }
        public decimal tips { get; set; }
        public decimal tips_card { get; set; }
        public decimal change_amount { get; set; }
        public string comments { get; set; }
        public Int16 payment_status { get; set; }
        public long restaurant_id { get; set; }
        public Int64 customer_id { get; set; }
        public string customer_first_name { get; set; }
        public string customer_last_name { get; set; }
        public string mobile_no { get; set; }
        public string telephone_no { get; set; }
        public byte order_transaction_status { get; set; }
        public byte no_of_guest { get; set; }
        public bool is_sync { get; set; }
        public DateTime order_date { get; set; }
        public string email { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string town { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public DateTime delivery_time { get; set; }
        public bool bill_print_status { get; set; }
        public float table_service_charge_percent { get; set; }
        public Int16 platform_id { get; set; }
        public string offer_text { get; set; }
        public string discount_text { get; set; }
        public Int64 created_by { get; set; }
        public int terminal_id { get; set; }
        public string orderToken { get; set; }
        public Nullable<decimal> distance { get; set; }
        public string duration { get; set; }
        public string order_status { get; set; }
        public string delivery_type { get; set; }
        public decimal bag_charge { get; set; }
        public int bag_quantity { get; set; }
        public string order_reference { get; set; }
        public string allergens { get; set; }

    }
}
