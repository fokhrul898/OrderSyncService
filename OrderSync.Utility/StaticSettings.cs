using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace OrderSync.Utility
{
    public class StaticSettings
    {
        private static readonly object padlock = new object();
        private static StaticSettings instance = null;

        private int timerGetOnlineOrderInterval;
        private int timerPostOrderServiceInterval;
        private int timerGetOnlineReservationInterval;
        private int timerPostOnlineOrderInterval;
        private int timerPostOnlineReservationInterval;
        private int timerPostOnlineOrderStatusUpdateServiceInterval;
        private int timerPostReservationServiceInterval;
        private int timerPostEposXReportToOnlineServiceInterval;

        private string logFilePath;
        private string logFileName;
        private long logFileSize;

        public int TimerGetOnlineOrderInterval { get { return timerGetOnlineOrderInterval; } }

        public int TimerPostOrderServiceInterval { get { return timerPostOrderServiceInterval; } }
        public int TimerGetOnlineReservationInterval { get { return timerGetOnlineReservationInterval; } }
        public int TimerPostOnlineOrderInterval { get { return timerPostOnlineOrderInterval; } }
        public int TimerPostOnlineReservationInterval { get { return timerPostOnlineReservationInterval; } }
        public int TimerPostOnlineOrderStatusUpdateServiceInterval { get { return timerPostOnlineOrderStatusUpdateServiceInterval; } }
        public int TimerPostReservationServiceInterval { get { return timerPostReservationServiceInterval; } }
        public int TimerPostEposXReportToOnlineServiceInterval { get { return timerPostEposXReportToOnlineServiceInterval; } }


        public string LogFilePath { get { return logFilePath; } }
        public string LogFileName { get { return logFileName; } }
        public long LogFileSize { get { return logFileSize; } }
        private StaticSettings()
        {
            if (!int.TryParse(GetAppConfigValueByKey("TimerGetOnlineOrderInterval"), out timerGetOnlineOrderInterval))
            {
                timerGetOnlineOrderInterval = 15000; // 15 seconds 
            }
            if (!int.TryParse(GetAppConfigValueByKey("TimerPostOrderServiceInterval"), out timerPostOrderServiceInterval))
            {
                timerPostOrderServiceInterval = 15000; // 15 seconds 
            }

            if (!int.TryParse(GetAppConfigValueByKey("TimerPostOnlineOrderStatusUpdateServiceInterval"), out timerPostOnlineOrderStatusUpdateServiceInterval))
            {
                timerPostOnlineOrderStatusUpdateServiceInterval = 15000; // 15 seconds 
            }



            if (!int.TryParse(GetAppConfigValueByKey("TimerGetOnlineReservationInterval"), out timerGetOnlineReservationInterval))
            {
                timerGetOnlineReservationInterval = 15000; // 15 seconds 
            }
            if (!int.TryParse(GetAppConfigValueByKey("TimerPostOnlineOrderInterval"), out timerPostOnlineOrderInterval))
            {
                timerPostOnlineOrderInterval = 15000; // 15 seconds 
            }
            if (!int.TryParse(GetAppConfigValueByKey("TimerPostOnlineReservationInterval"), out timerPostOnlineReservationInterval))
            {
                timerPostOnlineReservationInterval = 15000; // 15 seconds 
            }
            if (!int.TryParse(GetAppConfigValueByKey("TimerPostReservationServiceInterval"), out timerPostReservationServiceInterval))
            {
                timerPostReservationServiceInterval = 15000; // 15 seconds 
            }
            if (!int.TryParse(GetAppConfigValueByKey("TimerPostEposXReportToOnlineServiceInterval"), out timerPostEposXReportToOnlineServiceInterval))
            {
                timerPostEposXReportToOnlineServiceInterval = 1200000;
            }



            logFilePath = GetAppConfigValueByKey("LogFilePath");
            logFileName = GetAppConfigValueByKey("LogFileName");
            if (!Int64.TryParse(GetAppConfigValueByKey("LogFileSize"), out logFileSize))
            {
                logFileSize = 1;
            }
        }
        public static StaticSettings GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StaticSettings();
                    }
                    return instance;
                }
            }
        }

        private string GetAppConfigValueByKey(string key)
        {
            string value = string.Empty;
            try
            {                
                if (!string.IsNullOrEmpty(key))
                {
                    value = ConfigurationManager.AppSettings[key];
                }
                return value;
            }
            catch
            {
                return value;
            }
        }
    }
}
