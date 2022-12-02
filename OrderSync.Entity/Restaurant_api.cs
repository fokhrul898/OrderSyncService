using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Restaurant_api
    {
        public int id { get; set; }
        public Int64 restaurant_id { get; set; }
        public string api_url { get; set; }
        public string api_key { get; set; }
        public string api_name { get; set; }
        public Int64 created_by { get; set; }
        public Int64 updated_by { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
