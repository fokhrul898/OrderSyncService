using Newtonsoft.Json;
using OrderSync.Entity;
using OrderSync.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSync.DAL
{
    public class RestaurantReservationDAL
    {
        private static readonly object padlock = new object();
        private static RestaurantReservationDAL Instance = null;
        DirectoryInfo di;
        string OnlineBookingsrootpath = @"C:\OrderSync\OnlineBookings\";
        string PostBookingErrorsrootpath = @"C:\OrderSync\PostBookingErrors\";


        private RestaurantReservationDAL()
        {

        }

        public static RestaurantReservationDAL GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (Instance == null)
                    {
                        Instance = new RestaurantReservationDAL();
                    }
                    return Instance;
                }
            }
        }

        public bool SaveOnlineReservation(reservations reservation)
        {
            try
            {
                //Checked To Validate File Path
                if (!Directory.Exists(OnlineBookingsrootpath))
                {
                    // Try to create the directory.
                    di = Directory.CreateDirectory(OnlineBookingsrootpath);
                }
                File.WriteAllText(OnlineBookingsrootpath + reservation._id + ".txt", JsonConvert.SerializeObject(reservation));
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool SavePostReservationError(string _id, string errorMessage)
        {
            try
            {
                //Checked To Validate File Path
                if (!Directory.Exists(PostBookingErrorsrootpath))
                {
                    // Try to create the directory.
                    di = Directory.CreateDirectory(PostBookingErrorsrootpath);
                }
                File.WriteAllText(PostBookingErrorsrootpath + _id + ".txt", "{" + "_id:" + _id + ", errorMessage:" + errorMessage + "}");
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
