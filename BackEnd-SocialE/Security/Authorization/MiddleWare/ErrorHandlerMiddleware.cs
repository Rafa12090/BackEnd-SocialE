﻿using System.Net;
using System.Text.Json;
using BackEnd_SocialE.Security.Exceptions;

namespace BackEnd_SocialE.Security.Authorization.MiddleWare;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorHandlerMiddleware(RequestDelegate next) {
        _next = next;
    }
    public async Task Invoke(HttpContext context) {
        try { await _next(context); }
        catch (Exception error) {
            var response = context.Response;
            response.ContentType = "application/json";
            switch(error) {
                case AppException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest; break;
                case KeyNotFoundException e: break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}