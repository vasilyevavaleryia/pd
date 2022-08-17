using Microsoft.AspNetCore.Builder;


namespace ProProsecco.Helpers.ExtensionMethods
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
