using Microsoft.AspNetCore.Mvc;

namespace WorkApp.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public ActionResult<TestResult> Post()
        {
            // TODO: implement register on POST
            return new TestResult() { Result = "Ok", Payload = "Test data" };
        }

        public class TestResult
        {
            public string Result { get; set; }
            public string Payload { get; set; }
        }
    }
}
