using Newtonsoft.Json;
using OrderSync.DAL;
using OrderSync.Entity;
using OrderSync.Utility;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Timers;

namespace OnlineOrderSync.Service
{
    public partial class Service1 : ServiceBase
    {
        Timer TimerGetOnlineOrder = new Timer();
        Timer TimerPostOrderService = new Timer();
        Timer TimerPostOnlineOrderStatusUpdateService = new Timer();
        Timer TimerGetOnlineReservation = new Timer();
        Timer TimerPostEposXReportToOnlineService = new Timer();

        private string GetOnlineOrderURL = string.Empty;
        private string PostOnlineOrderURL = string.Empty;
        private string PostOnlineOrderErrorURL = string.Empty;
        private string GetOnlineReservationURL = string.Empty;
        private string PostOnlineReservationURL = string.Empty;
        private string GetUpdateOnlineOrderStatusURL = string.Empty;
        private string SyncZReportToOnlineURL = string.Empty;
        private string json;
        string PostOnlineOrdersrootpath = string.Empty;
        private List<orders> OnlineOrder;
        List<reservations> reservationList;
        private ZReportEntity zReport;
        private HttpWebRequest httpWebRequest;
        private HttpWebResponse httpResponse;
        string user = string.Empty;
        string computerName = string.Empty;
        public DateTime reportFrom;
        public DateTime reportTo;
        TimeSpan fromSpan = new TimeSpan(4, 0, 0);
        TimeSpan toSpan = new TimeSpan(3, 59, 59);
        FileInfo fi;
        StreamReader sr;

        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                ApplicationDataDAL.GetInstance.GenerateApplicationData();
                try
                {
                    GetOnlineOrderURL = ApplicationData.RestaurantApiList.Where(a => a.api_name == "GetOnlineOrderURL").FirstOrDefault().api_url + ApplicationData.Restaurant.id;
                }
                catch (Exception OOU)
                {
                    Logger.GetInstance.ExceptionWrite(OOU);
                }
                try
                {
                    PostOnlineOrderURL = ApplicationData.RestaurantApiList.Where(a => a.api_name == "PostOnlineOrderURL").FirstOrDefault().api_url;
                }
                catch (Exception POU)
                {
                    Logger.GetInstance.ExceptionWrite(POU);
                }
                try
                {
                    PostOnlineOrderErrorURL = ApplicationData.RestaurantApiList.Where(a => a.api_name == "PostOnlineOrderErrorURL").FirstOrDefault().api_url;
                }
                catch (Exception POEU)
                {
                    Logger.GetInstance.ExceptionWrite(POEU);
                }
                try
                {
                    GetOnlineReservationURL = ApplicationData.RestaurantApiList.Where(a => a.api_name == "GetOnlineReservationURL").FirstOrDefault().api_url + ApplicationData.Restaurant.id;
                }
                catch (Exception GORU)
                {
                    Logger.GetInstance.ExceptionWrite(GORU);
                }
                try
                {
                    PostOnlineReservationURL = ApplicationData.RestaurantApiList.Where(a => a.api_name == "PostOnlineReservationURL").FirstOrDefault().api_url;
                }
                catch (Exception PORU)
                {
                    Logger.GetInstance.ExceptionWrite(PORU);
                }

                try
                {
                    GetUpdateOnlineOrderStatusURL = ApplicationData.RestaurantApiList.Where(a => a.api_name == "GetUpdateOnlineOrderStatusURL").FirstOrDefault().api_url;
                }
                catch (Exception GUOSU)
                {
                    Logger.GetInstance.ExceptionWrite(GUOSU);
                }
                try
                {
                    SyncZReportToOnlineURL = ApplicationData.RestaurantApiList.Where(a => a.api_name == "SyncZReportToOnlineURL").FirstOrDefault().api_url;
                }
                catch (Exception GUOSU)
                {
                    Logger.GetInstance.ExceptionWrite(GUOSU);
                }
                try
                {
                    PostOnlineOrdersrootpath = @"C:\OrderSync\PostOnlineOrders\";
                }
                catch (Exception GUOSU)
                {
                    Logger.GetInstance.ExceptionWrite(GUOSU);
                }
                InitializeTimers();
            }
            catch (Exception ex)
            {
                RestaurantOrderDAL.GetInstance.RestartServiceOnlineOrderSync(ex.ToString());
                Logger.GetInstance.ExceptionWrite(ex);
            }
        }

        private void InitializeTimers()
        {
            try
            {
                Logger.GetInstance.LogWrite("Application Starts: Online Order Sync.");
                TimerGetOnlineOrder_Initialize();
                TimerPostOrderService_Initialize();
                TimerGetOnlineReservation_Initialize();
            }
            catch (Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
            }
        }

        private void TimerGetOnlineOrder_Initialize()
        {
            try
            {
                if (ApplicationData.restaurantSettings.online_order_sync_active)
                {
                    // 15 seconds Interval
                    TimerGetOnlineOrder.Interval = StaticSettings.GetInstance.TimerGetOnlineOrderInterval;

                    TimerGetOnlineOrder.Elapsed += new ElapsedEventHandler(this.TimerGetOnlineOrder_tick);
                    
                    TimerGetOnlineOrder.Start();
                    Logger.GetInstance.LogWrite("Get Online Order timer starts.");
                }
                else
                {
                    Logger.GetInstance.LogWrite("Get Online Order Is Not Active");
                }

            }
            catch (Exception ex)
            {
                RestaurantOrderDAL.GetInstance.RestartServiceOnlineOrderSync(ex.ToString());
                Logger.GetInstance.ExceptionWrite(ex);
            }

        }
        private void TimerPostOrderService_Initialize()
        {
            try
            {
                if (ApplicationData.restaurantSettings.online_order_sync_active)
                {
                    // 15 seconds Interval
                    TimerPostOrderService.Interval = StaticSettings.GetInstance.TimerPostOrderServiceInterval;

                    TimerPostOrderService.Elapsed += new ElapsedEventHandler(this.TimerPostOrderService_tick);

                    TimerPostOrderService.Start();
                    Logger.GetInstance.LogWrite("Post Online Order timer starts.");
                }
                else
                {
                    Logger.GetInstance.LogWrite("Post Online Order Is Not Active");
                }

            }
            catch (Exception ex)
            {
                RestaurantOrderDAL.GetInstance.RestartServiceOnlineOrderSync(ex.ToString());
                Logger.GetInstance.ExceptionWrite(ex);
            }

        }
        private void TimerPostOnlineOrderStatusUpdateService_Initialize()
        {
            try
            {
                if (ApplicationData.restaurantSettings.online_order_sync_active)
                {
                    // 15 seconds Interval
                    TimerPostOnlineOrderStatusUpdateService.Interval = StaticSettings.GetInstance.TimerPostOnlineOrderStatusUpdateServiceInterval;

                    TimerPostOnlineOrderStatusUpdateService.Elapsed += new ElapsedEventHandler(this.TimerPostOnlineOrderStatusUpdateService_tick);

                    TimerPostOnlineOrderStatusUpdateService.Start();
                    Logger.GetInstance.LogWrite("Post Online Order Status Update timer starts.");
                }
                else
                {
                    Logger.GetInstance.LogWrite("Post Online Order Status Update Is Not Active");
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
            }

        }
        private void TimerGetOnlineReservation_Initialize()
        {
            try
            {
                if (ApplicationData.restaurantSettings.online_reservation_sync_active)
                {
                    // 15 seconds Interval
                    TimerGetOnlineReservation.Interval = StaticSettings.GetInstance.TimerGetOnlineReservationInterval;

                    TimerGetOnlineReservation.Elapsed += new ElapsedEventHandler(this.TimerGetOnlineReservation_tick);

                    TimerGetOnlineReservation.Start();
                    Logger.GetInstance.LogWrite("Timer Get Online Reservation timer starts.");
                }
                else
                {
                    Logger.GetInstance.LogWrite("Timer Get Online Reservation Is Not Active");
                }
            }
            catch (Exception ex)
            {
                OnlineOrderStatusUpdateDAL.GetInstance.RestartServiceOnlineOrderSync(ex.ToString());
                Logger.GetInstance.ExceptionWrite(ex);
            }

        }
        private void TimerGetOnlineOrder_tick(object sender, ElapsedEventArgs e)
        {
            TimerGetOnlineOrder.Stop();
            try
            {
                if (ApplicationData.restaurantSettings.online_order_sync_active)
                {
                    using (WebClient wc = new WebClient())
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        bool NetworkConnectionIsAvailable = NetworkInterface.GetIsNetworkAvailable();
                       if (NetworkConnectionIsAvailable && IsInternetAvailable())
                        {
                            json = wc.DownloadString(GetOnlineOrderURL);
                            if (json != "[]")
                            {
                                OnlineOrder = JsonConvert.DeserializeObject<List<orders>>(json);
                                Logger.GetInstance.LogWrite("Total Order Found: " + OnlineOrder.Count.ToString());
                                if (OnlineOrder.Count > 0)
                                {
                                    foreach (var item in OnlineOrder)
                                    {

                                        if (RestaurantOrderDAL.GetInstance.SaveOnlineOrder(item))
                                        {
                                            PostOrder(item.order_id);//Needs to incorporate condition for order saved but post failed
                                        }
                                        else
                                        {
                                            PostError(item.order_id);//Needs to incorporate condition for Post Error Failed
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //Exception 
            catch /*(Exception ex)*/
            {
                 //OnlineOrderStatusUpdateDAL.GetInstance.RestartServiceOnlineOrderSync(ex.ToString());
                //Logger.GetInstance.ExceptionWrite(ex);
            }
            finally
            {
                TimerGetOnlineOrder.Start();
            }
        }
        private void TimerPostOrderService_tick(object sender, ElapsedEventArgs e)
        {
            TimerPostOrderService.Stop();
            try
            {
                if (ApplicationData.restaurantSettings.online_order_sync_active)
                {
                    if(Directory.Exists(PostOnlineOrdersrootpath))
                    {
                        string[] data = Directory.GetFiles(PostOnlineOrdersrootpath);
                        if (data != null)
                        {
                            if (data.Length > 0)
                            {
                                foreach (var orderId in data)
                                {
                                    fi = new FileInfo(orderId);
                                    sr = fi.OpenText();
                                    json = sr.ReadLine();
                                    Post_Order_Service PostOrderService = JsonConvert.DeserializeObject<Post_Order_Service>(json);
                                    if (PostOrderService != null)
                                    {
                                        PostOrder(PostOrderService.order_id, true);
                                        sr.Close();
                                        fi.Delete();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
            }
            finally
            {
                TimerPostOrderService.Start();
            }
        }
        private void TimerPostOnlineOrderStatusUpdateService_tick(object sender, ElapsedEventArgs e)
        {
            TimerPostOnlineOrderStatusUpdateService.Stop();
            try
            {
                if (ApplicationData.restaurantSettings.online_order_sync_active)
                {
                    List<Online_Order_Status_Update> data = OnlineOrderStatusUpdateDAL.GetInstance.GetOnlineOrderStatusUpdate();
                    if (data != null)
                    {
                        if (data.Count > 0)
                        {
                            foreach (Online_Order_Status_Update item in data)
                            {
                                PostAndUpdateOnlineOrderStatus(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RestaurantOrderDAL.GetInstance.RestartServiceOnlineOrderSync(ex.ToString());
                Logger.GetInstance.ExceptionWrite(ex);
            }
            finally
            {
                TimerPostOnlineOrderStatusUpdateService.Start();
            }
        }
        private void TimerGetOnlineReservation_tick(object sender, ElapsedEventArgs e)
        {
            TimerGetOnlineReservation.Stop();
            try
            {
                using (WebClient wc = new WebClient())
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    bool NetworkConnectionIsAvailable = NetworkInterface.GetIsNetworkAvailable();
                    if (NetworkConnectionIsAvailable && IsInternetAvailable())
                    {
                        json = wc.DownloadString(GetOnlineReservationURL);
                        if (json != "[]")
                        {
                            reservationList = JsonConvert.DeserializeObject<List<reservations>>(json);
                            if (reservationList.Count > 0)
                            {
                                foreach (var item in reservationList)
                                {
                                    if (RestaurantReservationDAL.GetInstance.SaveOnlineReservation(item))
                                    {
                                        if (item.payment_type != null)
                                        {
                                            if ((item.payment_type == "CARD" && item.payment_status) || item.payment_type != "CARD")
                                            {
                                                PostReservation(item._id);
                                            }
                                        }
                                        else
                                        {
                                            PostReservation(item._id);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        RestaurantOrderDAL.GetInstance.RestartServiceOnlineOrderSync("Network Connection Failed".ToString());
                        //Logger.GetInstance.ExceptionWrite(ex);
                    }
                }
            }
            catch /*(Exception ex)*/
            {
                //Logger.GetInstance.ExceptionWrite(ex);
            }
            finally
            {
                TimerGetOnlineReservation.Start();
            }
        }
        private void PostOrder(string order_id, bool? isLogPostOrder = null)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                httpWebRequest = (HttpWebRequest)WebRequest.Create(PostOnlineOrderURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = 20000; // 20 seconds

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    json = "{\"restaurant_id\":\"" + ApplicationData.Restaurant.id + "\"," +
                                  "\"order_id\":\"" + order_id + "\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {

                }
                if (isLogPostOrder != null)
                {
                    if (isLogPostOrder == true)
                    {
                        RestaurantOrderDAL.GetInstance.SavePostOrderServiceLog(order_id);
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    RestaurantOrderDAL.GetInstance.SavePostOrderService(order_id, ex.Message.ToString());
                    Logger.GetInstance.ExceptionWrite(ex);
                }
                catch (Exception e)
                {
                    Logger.GetInstance.ExceptionWrite(e);
                }
            }
        }
        private void PostError(string order_id)
        {
            try
            {   
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                httpWebRequest = (HttpWebRequest)WebRequest.Create(PostOnlineOrderErrorURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = 20000; // 20 seconds

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    json = "{\"restaurant_id\":\"" + ApplicationData.Restaurant.id + "\"," +
                                  "\"error_code\":\"500\"}" +
                                  "\"error_title\":\"print error\"}" +
                                  "\"description\":\"print error occured\"}" +
                                  "\"error_date\":\"" + DateTime.Now.ToString("yyyy-MM-dd") + "\"}" +
                                  "\"error_time\":\"" + DateTime.Now.ToString("hh:mm tt") + "\"}" +
                                  "\"order_id\":\"" + order_id + "\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();                    
                }
                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                }
            }
            catch(Exception ex)
            {
                Logger.GetInstance.ExceptionWrite(ex);
            }
        }
        public bool PostAndUpdateOnlineOrderStatus(Online_Order_Status_Update status_Update)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                httpWebRequest = (HttpWebRequest)WebRequest.Create(GetUpdateOnlineOrderStatusURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                httpWebRequest.Timeout = 20000; // 20 seconds

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    json = "{\"_id\":\"" + status_Update._id + "\"," +
                                  "\"order_status\":\"" + status_Update.order_status + "\"," +
                                  "\"delivery_time\":\"" + status_Update.delivery_time + "\"," +
                                  "\"message\":\"" + status_Update.message + "\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

               // OnlineOrderStatusUpdateDAL.GetInstance.LogOnlineOrderStatusUpdate(status_Update._id);
                return true;
            }
            catch(Exception ex)
            {
                //OnlineOrderStatusUpdateDAL.GetInstance.RestartServiceOnlineOrderSync(ex.ToString());
                Logger.GetInstance.ExceptionWrite(ex);
                return false;
            }
        }
       
        private void PostReservation(string reservationId)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                httpWebRequest = (HttpWebRequest)WebRequest.Create(PostOnlineReservationURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = 20000; // 20 seconds
                //httpWebRequest.ReadWriteTimeout

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    json = "{\"_id\":\"" + reservationId + "\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                }
            }
            catch(Exception ex)
            {
                try
                {
                    Logger.GetInstance.ExceptionWrite(ex);
                    RestaurantReservationDAL.GetInstance.SavePostReservationError(reservationId, ex.Message);
                }
                catch (Exception e)
                {
                    Logger.GetInstance.ExceptionWrite(e);
                }
            }
        }
        private void TimerPostEposXReportToOnline_Initialize()
        {
            try
            {
                if (ApplicationData.Restaurant.restaurant_id != string.Empty && ApplicationData.Restaurant.restaurant_id != null && ApplicationData.Restaurant.restaurant_id != " ")
                {
                    TimerPostEposXReportToOnlineService.Interval = StaticSettings.GetInstance.TimerPostEposXReportToOnlineServiceInterval;

                    TimerPostEposXReportToOnlineService.Elapsed += new ElapsedEventHandler(this.TimerPostEposXReportToOnlineService_tick);

                    TimerPostEposXReportToOnlineService.Start();
                    Logger.GetInstance.LogWrite("Post Epos XReport timer starts.");
                }
                else
                {
                    Logger.GetInstance.LogWrite("Post Epos XReport timer starts Is Not Active");
                }

            }
            catch (Exception ex)
            {
                //OnlineOrderStatusUpdateDAL.GetInstance.RestartServiceOnlineOrderSync(ex.ToString());
                Logger.GetInstance.ExceptionWrite(ex);
            }

        }
        
        private void TimerPostEposXReportToOnlineService_tick(object sender, ElapsedEventArgs e)
        {
            TimerPostEposXReportToOnlineService.Stop();
            try
            {
                if (ApplicationData.Restaurant.restaurant_id != string.Empty && ApplicationData.Restaurant.restaurant_id != null && ApplicationData.Restaurant.restaurant_id != " ")
                {
                    LoadDate(DateTime.Now);
                    zReport = OnlineOrderStatusUpdateDAL.GetInstance.GetZReport(reportFrom, reportTo);
                    if (zReport != null)
                    {
                        bool NetworkConnectionIsAvailable = NetworkInterface.GetIsNetworkAvailable();
                        if (NetworkConnectionIsAvailable)
                        {
                            ZReportSync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //OnlineOrderStatusUpdateDAL.GetInstance.RestartServiceOnlineOrderSync(ex.ToString());
                Logger.GetInstance.ExceptionWrite(ex);
            }
            finally
            {
                TimerPostEposXReportToOnlineService.Start();
            }
        }

        private void ZReportSync()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                httpWebRequest = (HttpWebRequest)WebRequest.Create(SyncZReportToOnlineURL);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = 20000; // 20 seconds

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string Json = JsonConvert.SerializeObject(zReport.zReportSummary);
                    Json = Json.Remove(Json.Length - 1, 1);
                    Json = Json + "," + "\"restaurant_id\":\"" + ApplicationData.Restaurant.restaurant_id + "\"}";
                    streamWriter.Write(Json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch
            {

            }
        }
        private void LoadDate(DateTime fromDate, Nullable<DateTime> toDate = null)
        {
            if (toDate == null)
            {
                toDate = fromDate;
            }
            reportFrom = fromDate.Date;
            reportTo = Convert.ToDateTime(toDate).Date;
            reportTo = reportTo.AddDays(1);
            reportFrom = reportFrom.Add(fromSpan);
            reportTo = reportTo.Add(toSpan);
        }
        private bool IsInternetAvailable()
        {
            try
            {
                Dns.GetHostEntry("www.google.com"); //using System.Net;
                return true;
            }
            catch
            {
                return false;
            }
        }
        protected override void OnStop()
        {
            TimerGetOnlineOrder.Enabled = false;
            //TimerGetOnlineReservation.Enabled = false;
            //TimerPostOnlineOrder.Enabled = false;
            //TimerPostOnlineReservation.Enabled = false;
            Logger.GetInstance.LogWrite("Application Stops: Online Order Sync.");
        }
    }
}
