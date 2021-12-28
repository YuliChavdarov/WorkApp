using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkApp.Web.Controllers
{
    /// <summary>
    /// Controller for handling uncaught exceptions.
    /// </summary>

    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route(ApiRoutes.ErrorDevelopment)]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }

        [Route(ApiRoutes.ErrorProduction)]
        public IActionResult HandleError() => Problem("An unexpected error occured on the server.");
    }
}
