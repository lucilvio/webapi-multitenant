using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiTenant.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentNullException || context.Exception is InvalidOperationException)
            {
                context.ExceptionHandled = true;
                context.Result = new BadRequestObjectResult(context.Exception.Message);
            }
        }
    }
}
