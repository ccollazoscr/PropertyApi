using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Property.Common.Exception;
using System.Net;

namespace PropertyApi.Exception
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            _ = app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    CustomErrorException contextFeature = context.Features.Get<CustomErrorException>();
                    if (contextFeature != null)
                    {
                        var lstErrors = contextFeature.GetListError();
                        if (lstErrors.Count > 0) {
                            context.Response.StatusCode = MapperStatusCode.GetHttpStatusCode(lstErrors[0].Code).GetHashCode();
                        }
                        else {
                            context.Response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                        }
                        
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(lstErrors));
                    }
                });
            });
        }

    }
}
