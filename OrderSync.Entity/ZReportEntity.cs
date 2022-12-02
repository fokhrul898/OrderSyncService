using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSync.Entity
{
    public class ZReportEntity
    {
        public ZReportSummary zReportSummary { get; set; }
    }
    public class ZReportSummary
    {
        public decimal Cash_Sale { get; set; }
        public decimal Card_sale { get; set; }
        public decimal Online_Card_Sale { get; set; }
        public decimal Gift_Voucher_Cash_Sale { get; set; }
        public decimal Gift_Voucher_Card_Sale { get; set; }
        public decimal Voucher_sale { get; set; }
        public decimal ePayment_Sale { get; set; }
        public decimal total_sale { get; set; }
        public int WalkingCount { get; set; }
        public decimal WalkingAmount { get; set; }
        public decimal WalkingCash_Sale { get; set; }
        public decimal WalkingCard_sale { get; set; }
        public decimal WalkingVoucher_sale { get; set; }
        public int ReservationCount { get; set; }
        public decimal ReservationAmount { get; set; }
        public decimal ReservationCash_Sale { get; set; }
        public decimal ReservationCard_sale { get; set; }
        public decimal ReservationVoucher_sale { get; set; }

        public int OnlineReservationCount { get; set; }
        public decimal OnlineReservationAmount { get; set; }
        public decimal OnlineReservationCash_Sale { get; set; }
        public decimal OnlineReservationCard_sale { get; set; }
        public decimal OnlineReservationVoucher_sale { get; set; }

        public int OflineOrderCount { get; set; }
        public decimal OflineOrderAmount { get; set; }
        public decimal OflineCash_Sale { get; set; }
        public decimal OflineCard_sale { get; set; }
        public decimal OflineVoucher_sale { get; set; }
        public int OnlineOrderCount { get; set; }
        public decimal OnlineOrderAmount { get; set; }
        public decimal OnlineCash_Sale { get; set; }
        public decimal OnlineCard_sale { get; set; }
        public decimal OnlineVoucher_sale { get; set; }
        public int DeliveryOrderCount { get; set; }
        public decimal DeliveryOrderAmount { get; set; }
        public int CollectionOrderCount { get; set; }
        public decimal CollectionOrderAmount { get; set; }
        public int WaitingOrderCount { get; set; }
        public decimal WaitingOrderAmount { get; set; }
        public decimal Service_charge { get; set; }
        public decimal discount_amount { get; set; }
        public decimal Cash_Tips { get; set; }
        public decimal Card_Tips { get; set; }
        public int no_of_guest { get; set; }
        public int items_Sold { get; set; }
        public int drinks_Sold { get; set; }
        public int Dine_in_Guest { get; set; }
        public int Takeaway_Customer { get; set; }
        public int WalkingCard_count { get; set; }
        public int ReservationCard_count { get; set; }
        public int OflineCardsale_Count { get; set; }
        public int OnlineOrderCardsale_count { get; set; }
        public decimal bag_charge { get; set; }
    }
}
