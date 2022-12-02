using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Utility
{
    public enum OrderPaymentType
    {
        Cash = 0,
        Card = 1,
        Discount = 2,
        Discount_Percent = 3,
        Service_Charge_Percent = 4,
        Cash_Tips = 5,
        Card_Tips = 6,
        Voucher = 7,
        Delivery_Charge = 8,
        Bag_Charge = 9
    }

    public enum OrderListFilterType
    {
        AllOrders = 0,
        TakeawayOrders = 1,
        TableOrders = 2
    }

    public enum PrintType
    {
        OpenDrawer = 0,
        PrintMessage = 1,
        ConfirmTakeawayOrder = 2,
        ReceiptTakeawayPrint = 3,
        ConfirmTableOrder = 4,
        ReceiptTablePrint = 5,
        ReservationPrint = 6,
        RePrintTakeaway = 7,
        ReprintTable = 8
    }
}
