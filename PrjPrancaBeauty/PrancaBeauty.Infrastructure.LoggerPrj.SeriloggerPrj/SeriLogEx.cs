using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;

namespace PrancaBeauty.Infrastructure.LoggerPrj.SeriloggerPrj
{
    public static class SeriLogEx
    {
        public static void UseSeriLog_SqlServer(this ConfigureHostBuilder webHostBuilder)
        {
            webHostBuilder.UseSerilog((builder, logger) =>
            {
                logger = new SerilogConfig().ConfigSqlServer(LogEventLevel.Warning);
                logger.CreateLogger();
            });
        }

        public static void UseSeriLog_Console(this ConfigureHostBuilder webHostBuilder)
        {
            webHostBuilder.UseSerilog((builder, logger) =>
            {
                logger.WriteTo.Console().MinimumLevel.Is(LogEventLevel.Verbose);
            });
        }
    }
}
