using GnomeVillage.Application.CommandHandlers;
using GnomeVillage.Application.Commands;
using GnomeVillage.Application.Queries;
using GnomeVillage.Application.QueryHandlers;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


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


         services.AddMediatR(new[] { 
            typeof(CommandHandlersReference).Assembly, 
            typeof(QueryHandlersReference).Assembly,
            typeof(CommandsReference).Assembly,
            typeof(QueriesReference).Assembly,
         });
         services.AddScoped<IQueryDispatcher, QueryDispatcher>();
         services.AddScoped<ICommandDispatcher, CommandDispatcher>();
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
