using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyApi.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
    .Where(e => e.Value?.ValidationState == ModelValidationState.Invalid)
    .ToDictionary(
        kvp => kvp.Key,
        kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
    );

                context.Result = new BadRequestObjectResult(new
                {
                    Message = "The request is invalid.",
                    ModelState = errors
                });
            }
        }
    }
}
