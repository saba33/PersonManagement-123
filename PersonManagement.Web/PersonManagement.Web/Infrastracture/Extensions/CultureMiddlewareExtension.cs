using Microsoft.AspNetCore.Builder;
using PersonManagement.Web.Infrastracture.Middlewares;


namespace PersonManagement.Web.Infrastracture.Extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddlware>();
        }
    }
}
