using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Groupwise_Option
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public string group_name { get; set; }
        public Nullable<short> sort_order { get; set; }
        public int dish_option_id { get; set; }
        public string option_name { get; set; }
        public decimal price { get; set; }
    }
}
