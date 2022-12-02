using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Printer_zone_setup
    {
        public int id { get; set; }
        public string zone { get; set; }
        public bool AllowBarPrint { get; set; }
        public Int16 zone_id { get; set; }
        public string printer_name { get; set; }
        public Int16 no_of_copies { get; set; }
        public bool status { get; set; }
        public long restaurant_id { get; set; }
        public bool AllowMessagePrint { get; set; }
        public bool IsDefaultKitchenPrinter { get; set; }
        public int Terminal_Id { get; set; }
        public int message_printer_terminal_id { get; set; }
    }
}
