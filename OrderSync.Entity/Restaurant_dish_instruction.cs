using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Restaurant_dish_instruction
    {
        public int id { get; set; }
        public Nullable<int> group_id { get; set; }
        public string instruction { get; set; }
        public Nullable<short> sort_order { get; set; }
        public decimal price { get; set; }
        public Nullable<long> parent_option_dish_id { get; set; }
        public bool is_parent { get; set; }

    }
}
