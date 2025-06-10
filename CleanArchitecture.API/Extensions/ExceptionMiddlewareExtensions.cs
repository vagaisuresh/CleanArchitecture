using System.Net;
using CleanArchitecture.API.Middleware;
using CleanArchitecture.API.Models;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanArchitecture.API.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
    
    /// <summary>
    /// Handling Errors Globally With the Built-In Middleware
    /// Use the below two lines in Program.cs after the line var app = builder.Build();
    /// //var logger = app.Services.GetRequiredService<ILoggerService>();
    /// //app.ConfigureExceptionHandler(logger);
    /// </summary>
    /// <param name="app"></param>
    /// <param name="logger"></param>
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerService logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    logger.LogError($"Something went wrong: {contextFeature.Error}");

                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal server error."
                    }.ToString());
                }
            });
        });
    }
}