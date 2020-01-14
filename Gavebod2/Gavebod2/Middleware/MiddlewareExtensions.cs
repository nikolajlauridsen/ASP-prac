using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace Gavebod2.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseFileLogger(this IApplicationBuilder app, FileLoggerOptions options)
        {
            return app.UseMiddleware<LoggerMiddleware>(Options.Create(options));
        }
    }
}
