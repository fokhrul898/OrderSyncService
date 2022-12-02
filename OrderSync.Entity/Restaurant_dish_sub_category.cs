using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Restaurant_dish_sub_category
    {
        public int id { get; set; }
        public long restaurant_id { get; set; }
        public string sub_category_name { get; set; }
        public bool is_enable_vat { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
    }
}
