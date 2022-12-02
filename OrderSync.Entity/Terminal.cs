using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class Terminal
    {
        public int id { get; set; }
        public string Computer_Name { get; set; }
        public string Computer_User { get; set; }
        public bool Can_Print { get; set; }
        public int Bill_printer_id { get; set; }
        public bool Allow_Cashdraw_Opeing { get; set; }
        public bool Allow_Bill_Printing { get; set; }
        public bool Allow_CallerID { get; set; }
        public int MessagePrinterID { get; set; }

    }
}
