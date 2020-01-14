using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Gavebod2.Middleware
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly FileLoggerOptions _options;

        public LoggerMiddleware(RequestDelegate next, IOptions<FileLoggerOptions> options)
        {
            _next = next;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            HttpRequest request = context.Request;
            StringBuilder requestLogMessageBuilder = new StringBuilder($"{DateTime.Now.ToString()}");
            requestLogMessageBuilder.Append($"\n{request.Method} - {request.Path.Value}{request.QueryString}");
            requestLogMessageBuilder.Append($"\nContent Type: {request.ContentType ?? "Not specified"}");
            requestLogMessageBuilder.Append($"\nHost: {request.Host}\n");
            await File.AppendAllTextAsync(_options.FileName, requestLogMessageBuilder.ToString());

            await _next(context);

            HttpResponse res = context.Response;
            
            requestLogMessageBuilder.Clear();
            requestLogMessageBuilder.Append($"Response\nStatus code: {res.StatusCode}\n\n");
            await File.AppendAllTextAsync(_options.FileName, requestLogMessageBuilder.ToString());

        }
    }
}
