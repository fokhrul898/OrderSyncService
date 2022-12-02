using OrderSync.Entity;
using OrderSync.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace OrderSync.DAL
{
    public class ApplicationDataDAL
    {
        private static readonly object padlock = new object();
        private static ApplicationDataDAL instance = null;
        private ApplicationDataDAL()
        {
        }
        public static ApplicationDataDAL GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ApplicationDataDAL();
                    }
                    return instance;
                }
            }
        }
        public void GenerateApplicationData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(UtilVarClass.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SPGetApplicationData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 60;

                        if (connection.State != ConnectionState.Open) { connection.Open(); }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                adapter.Fill(ds);
                                ApplicationData.Restaurant = (DataTableToListConverter.TableToList<Restaurants>(ds.Tables[0])).FirstOrDefault();
                                ApplicationData.RestaurantList = (DataTableToListConverter.TableToList<Restaurants>(ds.Tables[0]));
                                ApplicationData.ActiveOrderPolicy = DataTableToListConverter.TableToList<Restaurant_order_policy>(ds.Tables[1]);
                                ApplicationData.workingPlatform = (DataTableToListConverter.TableToList<Platform>(ds.Tables[2])).FirstOrDefault();
                                ApplicationData.Categories = DataTableToListConverter.TableToList<Dish_category>(ds.Tables[3]);
                                ApplicationData.Dishses = DataTableToListConverter.TableToList<Restaurant_dish>(ds.Tables[4]);
                                ApplicationData.allergens = DataTableToListConverter.TableToList<Allergens>(ds.Tables[5]);
                                ApplicationData.Courses = DataTableToListConverter.TableToList<Dish_Course>(ds.Tables[6]);
                                ApplicationData.miscDish = DataTableToListConverter.TableToList<Miscellaneous_Dish>(ds.Tables[7]);
                                ApplicationData.NoteList = DataTableToListConverter.TableToList<Default_Order_Note>(ds.Tables[8]);
                                ApplicationData.DefaultMessages = DataTableToListConverter.TableToList<Default_Message>(ds.Tables[9]);
                                ApplicationData.Printers = DataTableToListConverter.TableToList<Printer_zone_setup>(ds.Tables[11]);
                                ApplicationData.ScheduleList = DataTableToListConverter.TableToList<Restaurant_Schedule>(ds.Tables[12]);
                                ApplicationData.InstructionList = DataTableToListConverter.TableToList<Restaurant_dish_instruction>(ds.Tables[13]);
                                ApplicationData.CurrentNotification = DataTableToListConverter.TableToList<Notification>(ds.Tables[14]).FirstOrDefault();
                                ApplicationData.floorList = DataTableToListConverter.TableToList<Restaurant_floor>(ds.Tables[15]);
                                ApplicationData.shapeList = DataTableToListConverter.TableToList<Floor_Object_Shape>(ds.Tables[16]);
                                ApplicationData.typeList = DataTableToListConverter.TableToList<Floor_object_type>(ds.Tables[17]);
                                ApplicationData.floorObjectList = DataTableToListConverter.TableToList<Floor_object>(ds.Tables[18]);
                                ApplicationData.BusinessDay = DataTableToListConverter.TableToList<Restaurant_Business_Day>(ds.Tables[19]).FirstOrDefault();
                                ApplicationData.cardTypeList = DataTableToListConverter.TableToList<CardType>(ds.Tables[20]);
                                ApplicationData.userTypeList = DataTableToListConverter.TableToList<User_type>(ds.Tables[21]);
                                ApplicationData.printerZoneList = DataTableToListConverter.TableToList<Printer_Zone>(ds.Tables[22]);
                                ApplicationData.cuisineList = DataTableToListConverter.TableToList<Restaurant_Cuisine>(ds.Tables[23]);
                                ApplicationData.restaurantSettings = DataTableToListConverter.TableToList<RestaurantSettings>(ds.Tables[24]).ToList().FirstOrDefault();
                                ApplicationData.reservationList = DataTableToListConverter.TableToList<Restaurant_reservation>(ds.Tables[25]).ToList();
                                ApplicationData.dishSubcategoryList = DataTableToListConverter.TableToList<Restaurant_dish_sub_category>(ds.Tables[26]).ToList();
                                ApplicationData.Terminals = DataTableToListConverter.TableToList<Terminal>(ds.Tables[27]).ToList();
                                ApplicationData.optiongroupList = DataTableToListConverter.TableToList<Option_Group>(ds.Tables[28]).ToList();
                                ApplicationData.groupwiseoptionList = DataTableToListConverter.TableToList<Groupwise_Option>(ds.Tables[29]).ToList();
                                ApplicationData.dishgroupList = DataTableToListConverter.TableToList<Dish_Group>(ds.Tables[30]).ToList();
                                ApplicationData.onlineCardPaymentOrderList = DataTableToListConverter.TableToList<OnlineCardPaymentOrder>(ds.Tables[31]).ToList();
                                ApplicationData.ContactlessOrderTokenList = DataTableToListConverter.TableToList<Restaurant_order>(ds.Tables[32]).ToList();
                                ApplicationData.OfferDiscount = DataTableToListConverter.TableToList<Offer_Discount>(ds.Tables[33]).ToList();
                                ApplicationData.DeliveryCharge = DataTableToListConverter.TableToList<Delivery_Charge>(ds.Tables[34]).ToList();
                                ApplicationData.Users = DataTableToListConverter.TableToList<UserSettings>(ds.Tables[35]).ToList();
                                ApplicationData.RestaurantApiList = DataTableToListConverter.TableToList<Restaurant_api>(ds.Tables[36]).ToList();
                                ApplicationData.BagsList = DataTableToListConverter.TableToList<Bag_Charge>(ds.Tables[37]).ToList();
                                connection.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RestaurantOrderDAL.GetInstance.RestartServiceOnlineOrderSync(ex.ToString());
                throw new Exception("Database Error!!", ex);
            }

        }
    }
}
