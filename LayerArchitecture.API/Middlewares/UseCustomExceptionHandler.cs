﻿using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using LayerArchitecture.Core.DTOs;
using LayerArchitecture.Service.Exceptions;

namespace LayerArchitecture.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = 200; // Default to 200 OK
                    if (exceptionFeature != null)
                    {
                        statusCode = exceptionFeature.Error switch
                        {
                            ClientSideException => 400,
                            NotFoundException => 404,
                            _ => 500
                        };
                    }
                    context.Response.StatusCode = statusCode;

                    var response = exceptionFeature != null
                        ? CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message)
                        : CustomResponseDto<NoContentDto>.Success(statusCode);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }

    }
}
