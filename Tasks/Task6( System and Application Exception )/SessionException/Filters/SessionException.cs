using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;

namespace SessionException.Fiters{
  public class SessionExceptionFilterAttribute : ExceptionFilterAttribute
  {
      public override void OnException(ExceptionContext context)
    {
        if (context.Exception is InvalidOperationException)
        {
            // Custom error handling logic for the session-related exception
            var viewResult = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState)
                {
                    // Set a user-friendly error message in ViewData
                    { "ErrorMessage", "An error occurred while accessing the session. Please try again later or contact the administrator." }
                }
            };
            context.Result = viewResult;
            context.ExceptionHandled = true;
        }
    }
  }
}

