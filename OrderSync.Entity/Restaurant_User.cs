using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Restaurant_User
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string LoginTime { get; set; }
        public int user_type_id { get; set; }
        public string user_type { get; set; }
        public long user_log_id { get; set; }
        public string UserPassword { get; set; }
    }
}
