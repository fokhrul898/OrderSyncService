using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public partial class Restaurant_dish
    {
        public long id { get; set; }
        public long restaurant_id { get; set; }
        public int dish_category_id { get; set; }
        public Nullable<Int64> parent_dish_id { get; set; }
        public bool is_parent { get; set; }
        public string name { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> acm_price { get; set; }
        public Nullable<bool> exclude_from_offer { get; set; }
        public Nullable<bool> exclude_from_web { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<short> sort_order { get; set; }
        public Nullable<bool> is_favorite { get; set; }
        public string short_name { get; set; }
        public string dish_code { get; set; }
        public Nullable<int> group_id { get; set; }
        public Nullable<int> printer_zone_setup_id { get; set; }
        public Nullable<int> server_id { get; set; }
        public Nullable<int> category_print_order { get; set; }
        public string alternative_dish_name { get; set; }
        public string dish_description { get; set; }
        public string dish_name { get; set; }
        public Nullable<bool> hide_on_takeaway { get; set; }
        public Nullable<bool> hide_on_table { get; set; }
        public Nullable<int> printer_zone_setup_id_1 { get; set; }
        public Nullable<int> printer_zone_setup_id_2 { get; set; }
        public Nullable<int> expiry_date { get; set; }
        public Nullable<int> pack_size { get; set; }
        public string allergens { get; set; }
        public bool is_enable_vat { get; set; }
        public Nullable<int> print_order { get; set; }


    }
}
