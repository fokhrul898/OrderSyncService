using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Floor_object
    {
        public int id { get; set; }
        public string floor_object_name { get; set; }
        public int no_of_seat { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public decimal position_x { get; set; }
        public decimal position_y { get; set; }
        public int restaurant_floor_id { get; set; }
        public int floor_object_shape_id { get; set; }
        public int floor_object_type_id { get; set; }
    }
}
