using OrderSync.Utility;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderSync.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            string filePath = string.Empty;
            string fileName = string.Empty;
            long fileSize = 0;
            try
            {
                filePath = StaticSettings.GetInstance.LogFilePath;
                fileName = StaticSettings.GetInstance.LogFileName;
                fileSize = Convert.ToInt64(StaticSettings.GetInstance.LogFileSize);

                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            }
            catch
            {
                filePath = "C:\\OrderSync";
                fileName = "OnlineOrderLog.txt";
                fileSize = 10000000;
            }
            var logfile = Path.Combine(filePath, fileName);
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel
                            .Override("System", LogEventLevel.Error)
                            .WriteTo.File(logfile,
                                        rollingInterval: RollingInterval.Day,
                                        rollOnFileSizeLimit: true,
                                        fileSizeLimitBytes: fileSize,
                                        retainedFileCountLimit: null)
                            .CreateLogger();

            try
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, ex.Message);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
