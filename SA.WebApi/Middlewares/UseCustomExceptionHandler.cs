using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Diagnostics;
using SA.Business.CustomExceptions;
using SA.Model.Entities;
using System.Text.Json;

namespace SA.WebApi.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomExeption(this IApplicationBuilder app) 
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exeptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = StatusCodes.Status500InternalServerError;
                    //if (statusCode == StatusCodes.Status400BadRequest)
                    //{

                    //}
                    switch (exeptionFeature.Error)
                    {
                        case BadRequestException:
                            statusCode = StatusCodes.Status400BadRequest;
                            break;
                        case NoContentException:
                            statusCode = StatusCodes.Status204NoContent;
                            break;
                        case NotFoundException:
                            statusCode = StatusCodes.Status404NotFound;
                            break;
                    }
                    context.Response.StatusCode = statusCode;
                    var response = ApiResponse<Order>.Fail(statusCode, exeptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
