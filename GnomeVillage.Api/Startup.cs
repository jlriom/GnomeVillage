using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

namespace GnomeVillage.Api
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      public void ConfigureServices(IServiceCollection services)
      {
         services.AddControllers();

         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gnome Village API", Version = "v1" });
         });
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         app.UseSwagger();

         app.UseSwaggerUI(c =>
         {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gnome Village V1");
            c.RoutePrefix = string.Empty;
         });


         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseSerilogRequestLogging(options =>
         {
            options.MessageTemplate = "Handled {RequestPath}";
            options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;
            options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
            {
               diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
               diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
            };
         });

         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
