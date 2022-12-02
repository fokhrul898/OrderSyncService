using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class OnlineOrder
    {
        public List<orders> orders { get; set; }
        public List<reservations> reservations { get; set; }
    }
    public class orders
    {
        public string _id { get; set; }
        public string user_id { get; set; }
        public string order_id { get; set; }
        public string delivery_time { get; set; }
        public string order_time { get; set; }
        public delivery_address delivery_address { get; set; }
        public delivery_distance delivery_distance { get; set; }
        public delivery_duration delivery_duration { get; set; }
        public string card_payment_amount { get; set; }
        public string cash_payment_amount { get; set; }

        public string delivery_postcode { get; set; }
        public string order_policy { get; set; }
        public string payment_method { get; set; }
        public string offer_text { get; set; }
        public string discount_text { get; set; }
        public string discount_rate { get; set; }
        public string discount_type { get; set; }

        public string discount_amount { get; set; }
        public string delivery_charge { get; set; }
        public string service_charge { get; set; }
        public decimal sub_total { get; set; }
        public decimal grand_total { get; set; }
        public string order_status { get; set; }
        public string printed_at { get; set; }
        public string note_for_owner { get; set; }
        public string platform { get; set; }
        public string restaurant_id { get; set; }
        public string restaurant_name { get; set; }
        public string __v { get; set; }
        public string updated_at { get; set; }
        public string created_date { get; set; }
        public List<order_item> order_items { get; set; }
        public int pos_sync_status { get; set; }
        public int printing_status { get; set; }
        public int payment_status { get; set; }
        public customer_info customer_info { get; set; }
        public string order_date { get; set; }
        public string special_instruction { get; set; }
        public string delivery_type { get; set; }
        public string bag_charge { get; set; }
        public string vat_percent { get; set; }
        public string vat_amount { get; set; }
        public string coupon_text { get; set; }
        public string promoCode { get; set; }
        public string coupon_amount { get; set; }
        public decimal tips_amount { get; set; }

    }
    public class delivery_address
    {
        public string postcode { get; set; }
        public string country { get; set; }
        public string town { get; set; }
        public string address2 { get; set; }
        public string address1 { get; set; }
    }
    public class order_item
    {
        public string dish_id { get; set; }
        public string dish_name { get; set; }
        public string alt_dish_name { get; set; }
        public decimal unit_price { get; set; }
        public string dish_instruction { get; set; }
        public Nullable<decimal> summation_price { get; set; }
        public Nullable<decimal> total_price { get; set; }
        public int quantity { get; set; }
        public string _id { get; set; }
        public string dish_short_name { get; set; }
        public bool exclude_from_offer { get; set; }
        public List<dish_extras> dish_extra { get; set; }
        public Nullable<int> course_id { get; set; }
        public Nullable<int> dish_pack_size { get; set; }
        public bool is_sync { get; set; }
        public bool is_printed { get; set; }
        public int quantity_printed { get; set; }
        public string vat_rate { get; set; }
        public decimal vat_amount { get; set; }
        public string is_vat_included { get; set; }
    }
    public class DB_order_item
    {
        public string dish_name { get; set; }
        public string alternative_dish_name { get; set; }
        public decimal unit_price { get; set; }
        public string dish_instruction { get; set; }
        public int quantity { get; set; }
        public decimal total_price { get; set; }
        public int SortOrder { get; set; }
        public bool exclude_from_offer { get; set; }
        public string dish_short_name { get; set; }
        public int category_print_order { get; set; }
        public Nullable<int> dish_pack_size { get; set; }
    }
    public class customer_info
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone { get; set; }
        public string mobile_no { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string town { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
    }
    public class dish_extras
    {
        public List<options> option { get; set; }
    }
    public class options
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
    public class reservations
    {
        public string _id { get; set; }
        public string no_of_guest { get; set; }
        public string reservation_date { get; set; }
        public string reservation_time { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string mobile { get; set; }
        public string user_id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string postcode { get; set; }
        public string restaurant_id { get; set; }
        public string status { get; set; }
        public string booking_created_date { get; set; }
        public string __v { get; set; }
        public string updated_at { get; set; }
        public string created_date { get; set; }
        public string printing_status { get; set; }
        public string message_for_customer { get; set; }
        public string notes { get; set; }
        public string special_request { get; set; }
        public decimal grand_total { get; set; }
        public string payment_type { get; set; }
        public Boolean payment_status { get; set; }
    }
}
