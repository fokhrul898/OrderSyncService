using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Restaurant_reservation
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string mobile_no { get; set; }
        public string telephone_no { get; set; }
        public string email { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string town { get; set; }
        public string postcode { get; set; }
        public int short_order { get; set; }
        public string note { get; set; }
        public DateTime order_time { get; set; }
        public DateTime order_date { get; set; }
        public string fullName { get; set; }
        public string fullAddress { get; set; }
        public DateTime reservation_date { get; set; }
        public DateTime reservation_placement_date { get; set; }
        public string customer_name { get; set; }
        public string mobile { get; set; }
        public int no_of_guest { get; set; }
        public int customer_id { get; set; }
        public long restaurant_id { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string telephone { get; set; }
        public bool is_sync { get; set; }
        public string reservation_status_name { get; set; }
        public string assigntable_status_name { get; set; }
        public bool status { get; set; }
        public string reservation_status { get; set; }
        public string online_reservation_id { get; set; }
        public int platform_id { get; set; }

    }
}
