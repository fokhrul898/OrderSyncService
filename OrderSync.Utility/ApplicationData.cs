using OrderSync.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Utility
{
    public static class ApplicationData
    {
        public static Restaurants Restaurant { get; set; }
        public static List<Restaurants> RestaurantList { get; set; }
        public static RestaurantSettings restaurantSettings { get; set; }
        public static Restaurant_Business_Day BusinessDay { get; set; }
        public static List<Restaurant_order_policy> ActiveOrderPolicy { get; set; }
        public static Platform workingPlatform { get; set; }
        public static List<Restaurant_dish> Dishses { get; set; }
        public static List<Dish_category> Categories { get; set; }
        public static Restaurant_User User { get; set; }
        public static List<Allergens> allergens { get; set; }
        public static List<Dish_Course> Courses { get; set; }
        public static List<Miscellaneous_Dish> miscDish { get; set; }
        public static List<Default_Order_Note> NoteList { get; set; }
        public static List<Default_Message> DefaultMessages { get; set; }
        public static List<Printer_zone_setup> Printers { get; set; }
        public static List<Restaurant_Schedule> ScheduleList { get; set; }
        public static List<Restaurant_dish_instruction> InstructionList { get; set; }
        public static Notification CurrentNotification { get; set; }
        public static List<Restaurant_floor> floorList { get; set; }
        public static List<Floor_Object_Shape> shapeList { get; set; }
        public static List<Floor_object_type> typeList { get; set; }
        public static List<Floor_object> floorObjectList { get; set; }
        public static List<CardType> cardTypeList { get; set; }
        public static List<User_type> userTypeList { get; set; }
        public static List<Printer_Zone> printerZoneList { get; set; }
        public static List<Restaurant_Cuisine> cuisineList { get; set; }
        public static List<Restaurant_dish_sub_category> dishSubcategoryList { get; set; }
        public static List<Restaurant_reservation> reservationList { get; set; }
        public static int CategoryPerGrid = 7;
        public static int DishPerGrid = 7;
        public static int AllergensPerGrid = 4;
        public static bool TableUpdated = false;
        public static int UserInsertStatus { get; set; }
        public static List<Terminal> Terminals { get; set; }
        public static Terminal WorkingTerminal { get; set; }
        public static List<Option_Group> optiongroupList { get; set; }
        public static List<Groupwise_Option> groupwiseoptionList { get; set; }
        public static List<Dish_Group> dishgroupList { get; set; }
        public static List<OnlineCardPaymentOrder> onlineCardPaymentOrderList { get; set; }
        public static List<Restaurant_order> ContactlessOrderTokenList { get; set; }
        public static List<Offer_Discount> OfferDiscount { get; set; }
        public static List<Delivery_Charge> DeliveryCharge { get; set; }
        public static List<UserSettings> Users { get; set; }
        public static Restaurants RestaurantBasicInfo { get; set; }
        public static List<Restaurant_api> RestaurantApiList { get; set; }
        public static List<Bag_Charge> BagsList { get; set; }
        public static DateTime LastEventTime { get; set; }
    }
}
