using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Miscellaneous_Dish
    {
        public long id { get; set; }
        public string dish_name { get; set; }
        public decimal price { get; set; }
        public int course_id { get; set; }
    }
}
