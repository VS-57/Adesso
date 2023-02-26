﻿using System;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using Adesso.DTOs.Exceptions;
using Adesso.DTOs;

namespace Adesso.Middlewares
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

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientFaultException => 400,
                        UnauthorizedAccessException => 403,
                        //NotFoundException => 404,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;
                    var response = ResponseDto<NoDataDto>.Fail(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }
    }
}

