using Newtonsoft.Json;
using OrderSync.Entity;
using OrderSync.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace OrderSync.DAL
{
    public class RestaurantOrderDAL
    {
        DirectoryInfo di;
        string OnlineOrdersrootpath = @"C:\OrderSync\OnlineOrders\";
        string PostOnlineOrdersrootpath = @"C:\OrderSync\PostOnlineOrders\";
        string PostOnlineOrdersLogrootpath = @"C:\OrderSync\PostOnlineOrdersLog\";
        string RestartServiceOnlineOrderSyncrootpath = @"C:\OrderSync\RestartServiceOnlineOrderSync\";
        private static readonly object padlock = new object();
        private static RestaurantOrderDAL Instance = null;
        private RestaurantOrderDAL()
        {

        }
        public static RestaurantOrderDAL GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (Instance == null)
                    {
                        Instance = new RestaurantOrderDAL();
                    }
                    return Instance;
                }
            }
        }
        public bool SaveOnlineOrder(orders order)
        {
            try
            {
                //Checked To Validate File Path
                if (!Directory.Exists(OnlineOrdersrootpath))
                {
                    // Try to create the directory.
                    di = Directory.CreateDirectory(OnlineOrdersrootpath);
                }
                File.WriteAllText(OnlineOrdersrootpath + order.order_id + ".txt", JsonConvert.SerializeObject(order));
            }
            catch(Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
                return false;
            }
            return true;
        }

        public void SavePostOrderService(string order_id, string exception_message)
        {
            try
            {
                //Checked To Validate File Path
                if (!Directory.Exists(PostOnlineOrdersrootpath))
                {
                    // Try to create the directory.
                    di = Directory.CreateDirectory(PostOnlineOrdersrootpath);
                }
                File.WriteAllText(PostOnlineOrdersrootpath + order_id + ".txt", "{" + "order_id:" + order_id + "}");
            }
            catch (Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
            }
        }

        public List<Post_Order_Service> GetPostOrderService()
        {
            List<Post_Order_Service> ret = new List<Post_Order_Service>();
            try
            {
                using (SqlConnection connection = new SqlConnection(UtilVarClass.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GET_Post_Order_Service", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (connection.State != ConnectionState.Open) { connection.Open(); }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                adapter.Fill(ds);
                                ret =  (DataTableToListConverter.TableToList<Post_Order_Service>(ds.Tables[0]));
                                connection.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
                return new List<Post_Order_Service>();
            }

            return ret;
        }

        public List<Post_Order_Error_Service> GetPostOrderErrorService()
        {
            List<Post_Order_Error_Service> ret = new List<Post_Order_Error_Service>();
            try
            {
                using (SqlConnection connection = new SqlConnection(UtilVarClass.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GET_Post_Order_Error_Service", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (connection.State != ConnectionState.Open) { connection.Open(); }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                adapter.Fill(ds);
                                ret = (DataTableToListConverter.TableToList<Post_Order_Error_Service>(ds.Tables[0]));
                                connection.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
                return new List<Post_Order_Error_Service>();
            }

            return ret;
        }

        public void SavePostOrderServiceLog(string order_id)
        {
            try
            {
                //Checked To Validate File Path
                if (!Directory.Exists(PostOnlineOrdersLogrootpath))
                {
                    // Try to create the directory.
                    di = Directory.CreateDirectory(PostOnlineOrdersLogrootpath);
                }
                File.WriteAllText(PostOnlineOrdersLogrootpath + order_id + ".txt", JsonConvert.SerializeObject("{\"order_id\":\"" + order_id + "\"}"));
            }
            catch (Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
            }
        }

        public void SavePostOrderErrorService(string order_id, string exception_message)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(UtilVarClass.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Post_Order_Error_Service_Insert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@order_id", SqlDbType.NVarChar).Value = order_id;
                        command.Parameters.Add("@exception_message", SqlDbType.NVarChar).Value = exception_message;


                        if (connection.State != ConnectionState.Open) { connection.Open(); }
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
            }
        }

        public void SavePostOrderErrorServiceLog(string order_id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(UtilVarClass.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Post_Order_Error_Service_Log_Insert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@order_id", SqlDbType.NVarChar).Value = order_id;

                        if (connection.State != ConnectionState.Open) { connection.Open(); }
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
            }
        }

        public void RestartServiceOnlineOrderSync(string message)
        {
            try
            {
                //Checked To Validate File Path
                if (!Directory.Exists(RestartServiceOnlineOrderSyncrootpath))
                {
                    // Try to create the directory.
                    di = Directory.CreateDirectory(RestartServiceOnlineOrderSyncrootpath);
                }
                File.WriteAllText(PostOnlineOrdersLogrootpath + "RestartServiceOnlineOrderSync.txt", JsonConvert.SerializeObject("{\"Error Message\":\"" + message + "\"}"));
            }
            catch (Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
            }
        }



    }
}
