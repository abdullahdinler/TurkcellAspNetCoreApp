using System.Net;

//  Bu Middleware, gelen isteklerin IP adreslerini kontrol eder ve yalnızca belirli bir IP adresine sahip olan istekleri kabul eder. 



namespace Middleware.Example.Web.Middlewares
{
    public class WhiteIpAddressControlMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private const string WhiteIpAddress = "::1";

        public WhiteIpAddressControlMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // İstek yapan istemcinin IP adresini alır.
            var reqIpAddress = context.Connection.RemoteIpAddress;

            //Kabul edilebilir IP adresiyle karşılaştırır.
            bool anyWhiteIpAddress = IPAddress.Parse(WhiteIpAddress).Equals(reqIpAddress);


            if (anyWhiteIpAddress)
            {
                // Sonraki Middleware veya Controller'a isteği iletir.
                await _requestDelegate(context);
            }
            else
            {
                context.Response.StatusCode = HttpStatusCode.Forbidden.GetHashCode();
               await context.Response.WriteAsync("Forbiden");
            }
        }
    }
}
