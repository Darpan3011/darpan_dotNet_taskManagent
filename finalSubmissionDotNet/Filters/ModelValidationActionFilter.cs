using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace finalSubmissionDotNet.Filters
{
    public class ModelValidationActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                // Return a BadRequest with validation errors
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }

            // If ModelState is valid, proceed to the next stage of the pipeline
            await next();
        }
    }
}
