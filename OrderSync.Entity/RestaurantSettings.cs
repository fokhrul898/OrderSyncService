using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Entity
{
    public class RestaurantSettings
    {
        public Int16 id { get; set; }
        public long restaurant_id { get; set; }
        public bool show_confirmOrder { get; set; }
        public bool alow_BillPrintOnConfirm { get; set; }
        public bool enable_CardInfo { get; set; }
        public bool enable_Confirmation_VoidDishStaff { get; set; }
        public bool enable_Confirmation_Discount { get; set; }
        public bool show_subCategory_Over_Favorite { get; set; }
        public bool show_Price_in_Kitchen { get; set; }
        public bool enable_online_card_payment { get; set; }
        public bool enable_alternative_language { get; set; }
        public Int16 kitchen_receipt_font_size { get; set; }
        public Int16 receipt_right_pade { get; set; }
        public bool open_cashdraw_confirmationForStaff { get; set; }
        public string BillReceiptCustomMessage { get; set; }
        public bool online_order_sync_active { get; set; }
        public bool online_reservation_sync_active { get; set; }
        public bool enable_closed_order_change { get; set; }
        public bool order_alert { get; set; }
        public decimal takeaway_order_discount_percent { get; set; }
        public Int16 font_receipt_right_pad { get; set; }
        public bool show_payment_type_on_confirm { get; set; }
        public Int16 kitchen_receipt_top_pad { get; set; }
        public bool enable_contactless_order { get; set; }
        public bool alow_label_print { get; set; }
        public bool active_delivery_charge { get; set; }
        public bool active_restaurant_address_in_kitchen_recepit { get; set; }
        public int default_logout_time { get; set; }
        public int Category_Columns { get; set; }
        public int Dish_Columns { get; set; }
    }
}
