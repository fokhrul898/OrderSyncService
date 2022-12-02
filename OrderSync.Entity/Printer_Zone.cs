using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Printer_Zone
    {
        public Int16 id { get; set; }
        public string Name { get; set; }
        public bool AllowBarPrint { get; set; }
        public bool AllowMessagePrint { get; set; }
        public bool IsDefaultKitchenPrinter { get; set; }
        public bool Status { get; set; }
    }
}
