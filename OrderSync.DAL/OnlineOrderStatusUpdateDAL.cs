using OrderSync.Entity;
using OrderSync.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace OrderSync.DAL
{
    public class OnlineOrderStatusUpdateDAL
    {
        private static readonly object padlock = new object();
        private static OnlineOrderStatusUpdateDAL instance = null;
        private OnlineOrderStatusUpdateDAL()
        {

        }

        public static OnlineOrderStatusUpdateDAL GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new OnlineOrderStatusUpdateDAL();
                    }
                    return instance;
                }
            }
        }

        public List<Online_Order_Status_Update> GetOnlineOrderStatusUpdate()
        {
            List<Online_Order_Status_Update> ret = new List<Online_Order_Status_Update>();
            try
            {
                using (SqlConnection connection = new SqlConnection(UtilVarClass.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SPGet_Online_Order_Status_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (connection.State != ConnectionState.Open) { connection.Open(); }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                adapter.Fill(ds);
                                ret = (DataTableToListConverter.TableToList<Online_Order_Status_Update>(ds.Tables[0]));
                                connection.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
                return new List<Online_Order_Status_Update>();
            }

            return ret;
        }

        public void LogOnlineOrderStatusUpdate(string _id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(UtilVarClass.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Log_Online_Order_Status_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@_id", SqlDbType.NVarChar).Value = _id;
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
        public ZReportEntity GetZReport(DateTime startDate, DateTime endDate)
        {
            ZReportEntity zReportEntity = new ZReportEntity();
            try
            {
                using (SqlConnection connection = new SqlConnection(UtilVarClass.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SPZReport", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@from_date_time", SqlDbType.DateTime).Value = startDate;
                        command.Parameters.Add("@to_date_time", SqlDbType.DateTime).Value = endDate;
                        command.CommandType = CommandType.StoredProcedure;

                        if (connection.State != ConnectionState.Open) { connection.Open(); }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                adapter.Fill(ds);
                                zReportEntity.zReportSummary = (DataTableToListConverter.TableToList<ZReportSummary>(ds.Tables[0])).FirstOrDefault();
                                connection.Close();
                                return zReportEntity;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error!!", ex);
            }
        }

        public void RestartServiceOnlineOrderSync(string message)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(UtilVarClass.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SPInsertRestartServiceOnlineOrderSync", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@exception_message", SqlDbType.NVarChar).Value = message;
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
    }
}
