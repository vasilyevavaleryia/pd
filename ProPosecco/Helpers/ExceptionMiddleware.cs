using Microsoft.AspNetCore.Http;
using ProProsecco.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ProProsecco.Helpers
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            if (context.Request.Path.Value.ToLower().StartsWith("/api"))
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync(new ErrorDetailsModel()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server error"
                }.ToString());
            }
            else
            {
                context.Response.Redirect("/error");
            }
        }
    }
}
