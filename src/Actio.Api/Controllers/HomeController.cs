using Microsoft.AspNetCore.Mvc;

namespace Actio.Api.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [HttpGet()]
        public ActionResult Get() => Content("Hello simple microservice");
    }
}