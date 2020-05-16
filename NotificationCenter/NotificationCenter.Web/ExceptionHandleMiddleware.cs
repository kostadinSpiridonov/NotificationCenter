using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NotificationCenter.Core;
using System;
using System.Threading.Tasks;

namespace NotificationCenter.Web
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {

            }
            
        }
    }
}