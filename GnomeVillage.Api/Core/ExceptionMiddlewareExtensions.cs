using GnomeVillage.Application.Common.Exceptions;
using GnomeVillage.Domain.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GnomeVillage.Api.Core
{
   public static class ExceptionMiddlewareExtensions
   {
      public static void ConfigureExceptionHandler(this IApplicationBuilder app)
      {
         app.UseExceptionHandler(errorApp =>
         {
            errorApp.Run(async context =>
            {

               context.Response.ContentType = "application/json";
               context.Response.StatusCode = StatusCodes.Status500InternalServerError;

               var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

               if (exceptionHandlerPathFeature?.Error != null)
               {
                  var body = JsonConvert.SerializeObject(exceptionHandlerPathFeature?.Error);
                  if (exceptionHandlerPathFeature?.Error is AppException || exceptionHandlerPathFeature?.Error is DomainException)
                  {
                     context.Response.StatusCode = StatusCodes.Status400BadRequest;
                  }
                  else if (exceptionHandlerPathFeature?.Error is NotFoundException)
                  {
                     context.Response.StatusCode = StatusCodes.Status404NotFound;
                  }
                  else if (exceptionHandlerPathFeature?.Error is UnauthorizedException)
                  {
                     context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                  }
                  await context.Response.WriteAsync(body);
               }
            });
         });
      }
   }
}
