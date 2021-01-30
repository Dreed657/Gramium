using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gramium.Server.Infrastructure.Filters
{
    public class ModelOrNotFoundActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult result)
            {
                var model = result.Value;

                if (model == null)
                {
                    context.Result = new NotFoundResult();
                }
            }
        }
    }
}
