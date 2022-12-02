using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public partial class Dish_category
    {
        public int id { get; set; }
        public int sort_order { get; set; }
        public string name { get; set; }
        public long restaurant_cuisine_id { get; set; }
        public string short_name { get; set; }
        public Nullable<int> group_id { get; set; }
        public Nullable<int> printer_zone_id { get; set; }
        public Nullable<int> restaurant_dish_sub_category_id { get; set; }
        public int print_order { get; set; }
        public string category_name { get; set; }
        public string description { get; set; }
        public bool ChildInReverseOrder { get; set; }
        public Nullable<bool> exclude_from_offer { get; set; }
        public Nullable<int> printer_zone_setup_id_1 { get; set; }
        public Nullable<int> printer_zone_setup_id_2 { get; set; }
        public bool is_enable_vat { get; set; }
        public Nullable<bool> hide_on_takeaway { get; set; }
        public Nullable<bool> hide_on_table { get; set; }
    }
}
