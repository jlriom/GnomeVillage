using AutoMapper;
using GnomeVillage.Api.Core;
using GnomeVillage.Application.CommandHandlers;
using GnomeVillage.Application.Commands;
using GnomeVillage.Application.Queries;
using GnomeVillage.Application.QueryHandlers;
using GnomeVillage.Application.QueryHandlers.Mappings;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using GnomeVillage.Data;
using GnomeVillage.Domain.Implementation.Mappings;
using GnomeVillage.Domain.Models;
using GnomeVillage.ReadModel.Implementation.Mappings;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

         services.AddDbContext<GnomeVillageContext>(options =>
         {
            options.UseSqlServer(Configuration.GetConnectionString("GnomeVillageContext"));
            options.EnableSensitiveDataLogging(true);
            options.EnableDetailedErrors(true);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); 

         });


         services.AddScoped<IUser, User>();
         services.AddScoped<IQueryDispatcher, QueryDispatcher>();
         services.AddScoped<ICommandDispatcher, CommandDispatcher>();
         services.AddMediatR(new[] {
            typeof(CommandHandlersReference).Assembly,
            typeof(QueryHandlersReference).Assembly,
            typeof(CommandsReference).Assembly,
            typeof(QueriesReference).Assembly,
         });

         services.AddScoped<ReadModel.Contracts.IHabitantReadOnlyRepository, ReadModel.Implementation.HabitantReadOnlyRepository> ();
         services.AddScoped<ReadModel.Contracts.IHairColorReadonlyRepository, ReadModel.Implementation.HairColorReadonlyRepository>();
         services.AddScoped<ReadModel.Contracts.IProfessionReadOnlyRepository, ReadModel.Implementation.ProfessionReadOnlyRepository> ();

         services.AddScoped<HabitantInsertValidator>();
         services.AddScoped<HabitantUpdateValidator>();
         services.AddScoped<HabitantDeleteValidator>();
         services.AddScoped<HabitantAddFriendValidator>();
         services.AddScoped<HabitantRemoveFriendValidator>();

         services.AddScoped<Domain.IHabitantReadOnlyRepository, Domain.Implementation.HabitantReadOnlyRepository>();
         services.AddScoped<Domain.IHabitantRepository, Domain.Implementation.HabitantRepository> ();
         services.AddScoped<Domain.IHairColorReadonlyRepository, Domain.Implementation.HairColorReadonlyRepository> ();
         services.AddScoped<Domain.IProfessionReadonlyRepository, Domain.Implementation.ProfessionReadonlyRepository> ();

         services.AddAutoMapper(
            typeof(ApplicationQueryMappingReference),
            typeof(ReadModelMappingReference),
            typeof(DomainMappingsReference));
      }

      public void Configure(IApplicationBuilder app)
      {

         app.UseSwagger();

         app.UseSwaggerUI(c =>
         {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gnome Village V1");
            c.RoutePrefix = string.Empty;
         });

         app.ConfigureExceptionHandler();

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
