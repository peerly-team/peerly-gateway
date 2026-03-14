using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Peerly.Gateway.Api.Models.Common;

namespace Peerly.Gateway.Api.Infrastructure.Filters;

internal sealed class ModelStateFilterAttribute : TypeFilterAttribute
{
    public ModelStateFilterAttribute()
        : base(typeof(ModelStateFilter))
    {
    }

    private sealed class ModelStateFilter : IActionFilter
    {
        private readonly ProblemDetailsFactory _problemDetailsFactory;

        public ModelStateFilter(ProblemDetailsFactory problemDetailsFactory)
        {
            _problemDetailsFactory = problemDetailsFactory;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            var problemDetails = _problemDetailsFactory.CreateValidationProblemDetails(context.HttpContext, context.ModelState);

            problemDetails.Extensions["source"] = ValidationSource.ModelState;

            context.Result = new BadRequestObjectResult(problemDetails);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
