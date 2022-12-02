using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class UserSettings
    {
        public int id { get; set; }
        public long restaurant_id { get; set; }
        public string user_name { get; set; }
        public string full_name { get; set; }
        public bool status { get; set; }
        public string mobile_no { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string telephone_no { get; set; }
        public int user_type_id { get; set; }
        public string user_type_name { get; set; }
        public string pin_no { get; set; }
        public string image_location { get; set; }
        public DateTime created_at { get; set; }
        public Nullable<DateTime> updated_at { get; set; }
        public int created_by { get; set; }
        public Nullable<int> updated_by { get; set; }
    }
}
