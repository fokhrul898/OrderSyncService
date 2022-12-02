using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Dish_Group
    {
        public int id { get; set; }
        public Nullable<Int64> dish_id { get; set; }
        public string dish_name { get; set; }
        public Nullable<int> category_id { get; set; }
        public int group_id { get; set; }
        public string group_name { get; set; }
    }
}
