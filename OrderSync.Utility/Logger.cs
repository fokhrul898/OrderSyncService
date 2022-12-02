using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSync.Utility
{
    public class Logger
    {
        private static readonly object padlock = new object();
        private static Logger instance = null;

        private readonly ILogger _log = Log.ForContext<Logger>();

        public static Logger GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                    return instance;
                }
            }
        }
        private Logger()
        {

        }

        public void LogWrite(string logMessage)
        {
            try
            {
                _log.Error(logMessage);
            }
            catch
            {
            }
        }
        public void ExceptionWrite(Exception ex)
        {
            try
            {
                _log.Fatal(ex, ex.Message);
            }
            catch
            {
            }
        }
    }
}
