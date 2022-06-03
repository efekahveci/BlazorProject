using System;
using System.Net;
using BlazorProject.Common.Exceptions;
using BlazorProject.Common.Results;
using Microsoft.AspNetCore.Diagnostics;

namespace BlazorProject.Api.WebApi.Extensions;

public static class ApplicationBuilderExtension
{
   public static IApplicationBuilder ConfigureExceptionHandling(this IApplicationBuilder app,bool includeExceptionDetails=false,bool useDefaultHandlingResponse=true,
       Func<HttpContext,Exception, Task> handleException = null)
    {
        app.UseExceptionHandler(options =>
        {
            options.Run(context =>
            {

                var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();

                if (!useDefaultHandlingResponse && handleException == null)
                    throw new ArgumentException(nameof(handleException), $"{nameof(handleException)} cannot be null when {nameof(useDefaultHandlingResponse)} is false");

                if (!useDefaultHandlingResponse && handleException != null)
                    return handleException(context, exceptionObject.Error);

                return DefaultHandleException(context, exceptionObject.Error, includeExceptionDetails);

            });
        });
        
   

        return app;
    }

    //TODO loglama ile detaylı mesajşlar db ye normal exceptionlar kullanıcıya gösterilecek
    private static async Task DefaultHandleException(HttpContext context , Exception exception, bool includeDetail)
    {

        HttpStatusCode code = HttpStatusCode.InternalServerError;
        string message = "Internal Server Error";

        if (exception is UnauthorizedAccessException)
            code = HttpStatusCode.Unauthorized;

        if(exception is DbValidEx)
        {
            var response = new ValidationResponseModel() { Errors = new List<string>() { exception.Message } };
            await WriteReponse(context, code, response);
            return;

        }

        var res = new
        {
            HttpStatusCode = (int)code,
            Detail = includeDetail ? exception.ToString() : message
        };

        await WriteReponse(context,code, res);
        
  
    }

    private static async Task WriteReponse(HttpContext context, HttpStatusCode statusCode, object responseObj)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsJsonAsync(responseObj);
    }

}
