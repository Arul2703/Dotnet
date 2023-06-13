using System.Net;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CookieException.Filters{
  public class HandleCookieExceptionAttribute : ExceptionFilterAttribute
  {
      private readonly ILogger<HandleCookieExceptionAttribute> _logger;

      public HandleCookieExceptionAttribute(ILogger<HandleCookieExceptionAttribute> logger)
      {
          _logger = logger;
      }

      public override void OnException(ExceptionContext context)
      {
          if (context.Exception is InvalidOperationException)
          {
              context.Result = new ViewResult
              {
                  ViewName = "Error",
                  ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState)
                  {
                      ["ErrorMessage"] = "Invalid operation occurred while working with cookies."
                  },
                  StatusCode = (int)HttpStatusCode.BadRequest
              };
          }
          else if (context.Exception is ArgumentException)
          {
              context.Result = new ViewResult
              {
                  ViewName = "Error",
                  ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState)
                  {
                      ["ErrorMessage"] = "Invalid argument provided for cookie operation."
                  },
                  StatusCode = (int)HttpStatusCode.BadRequest
              };
          }
          context.ExceptionHandled = true;
      }
  }
}
