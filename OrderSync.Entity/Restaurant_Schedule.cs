using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Restaurant_Schedule
    {
        public long id { get; set; }
        public short from_weekday { get; set; }
        public short to_weekday { get; set; }
        public TimeSpan opening_time { get; set; }
        public TimeSpan closing_time { get; set; }
        public Int16 delivery_minutes { get; set; }
        public Int16 collection_minutes { get; set; }
        public bool status { get; set; }
    }
}
