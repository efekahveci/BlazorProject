using Microsoft.AspNetCore.Mvc.Filters;

namespace BlazorProject.Api.WebApi.Infrastructure.ActionFilters;

public class ValidateModelStateFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var messages = context.ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage).ToList();
            return;
        }

        await next();
    }
}
