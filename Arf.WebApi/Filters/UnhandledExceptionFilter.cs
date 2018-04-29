using Serilog;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Arf.WebApi.Filters
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        private static readonly ILogger lh = Log.Logger.ForContext<UnhandledExceptionFilter>();

        public override void OnException(HttpActionExecutedContext context)
        {
            lh.Error(context.Exception, "UnhandledExceptionFilter");
            var httpResponseException = context.Exception as HttpResponseException;
            if (httpResponseException != null)
            {
                var content = httpResponseException.Response.Content.ReadAsStringAsync().Result;

                lh.Error(
                    $"UnhandledExceptionFilter response status code: {httpResponseException.Response.StatusCode}, content: {content}");
            }
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error occurred, please try again or contact the administrator."),
                ReasonPhrase = "Critical Exception"
            });
        }
    }
}