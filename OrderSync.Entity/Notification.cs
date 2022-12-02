using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Notification
    {
        public int ReservationToday { get; set; }
        public int ReservationTomorrow { get; set; }
        public int DeliveryCount { get; set; }
        public int CollectionCount { get; set; }
        public int WaitingCount { get; set; }
        public int TotalTakeaway { get; set; }
        public int TableOrdersCount { get; set; }
        public int BarTabCount { get; set; }
    }
}
