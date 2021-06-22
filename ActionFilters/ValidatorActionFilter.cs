using MemberProject.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MemberProject.ActionFilters
{
    public class ValidatorActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                string ErrorMessage = string.Empty;
                var values = filterContext.ModelState.Values;

                foreach (var item in values)
                {
                    foreach (var error in item.Errors)
                    {
                        ErrorMessage += error.ErrorMessage + ",";
                    }
                }

                ErrorMessage = ErrorMessage.Trim(',');

                IResponseDTO responseDTO = new ResponseDTO() { Data = null, IsPassed = false, Message = ErrorMessage };

                //filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);

                filterContext.Result = new JsonResult(responseDTO)
                {
                    StatusCode = StatusCodes.Status200OK // Status code here 
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}
