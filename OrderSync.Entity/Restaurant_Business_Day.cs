using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Restaurant_Business_Day
    {
        public int id { get; set; }
        public TimeSpan Start_time { get; set; }
        public TimeSpan end_time { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
