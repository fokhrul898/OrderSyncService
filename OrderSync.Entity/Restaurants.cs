using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Restaurants
    {
        public long id { get; set; }
        public string restaurant_id { get; set; }
        public string restaurant_name { get; set; }
        public string domain { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string town { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public Nullable<decimal> latitude { get; set; }
        public Nullable<decimal> longitude { get; set; }
        public bool status { get; set; }
        public string business_tel { get; set; }
        public string vat_no { get; set; }
        public float table_service_charge_percent { get; set; }
        public bool is_multi_terminal_supported { get; set; }
        public bool is_card_info_enabled { get; set; }
        public bool is_auto_print_takeaway_enabled { get; set; }
        public bool is_auto_print_table_enabled { get; set; }
        public decimal vat_percent { get; set; }
        public bool is_drawer_open_on_cash_payment { get; set; }
        public bool is_drawer_open_on_card_payment { get; set; }
        public bool is_tablet_payment_enabled { get; set; }
        public string server_computer_name { get; set; }
        public string computer_user { get; set; }
        public string rest_sec { get; set; }
        public bool is_ordering { get; set; }
        public bool is_reservation { get; set; }
        public bool auto_accept_order { get; set; }
        public bool auto_accept_reservation { get; set; }
    }
}
