using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Reflection;

namespace GnomeVillage.Api
{
   public static class Program
   {
      public static int Main(string[] args)
      {
         Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
             .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
             .Enrich.FromLogContext()
             .WriteTo.Console()
             .WriteTo.File(
                $"./{Assembly.GetExecutingAssembly().GetName().Name}.log",
                fileSizeLimitBytes: 1_000_000,
                rollOnFileSizeLimit: true,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1))
             .CreateLogger();

         try
         {
            Log.Information("Starting web host");
            CreateHostBuilder(args).Build().Run();
            return 0;
         }
         catch (Exception ex)
         {
            Log.Fatal(ex, "Host terminated unexpectedly");
            return 1;
         }
         finally
         {
            Log.CloseAndFlush();
         }
      }

      public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
               webBuilder.UseStartup<Startup>();
            })
            .UseSerilog();
   }
}
