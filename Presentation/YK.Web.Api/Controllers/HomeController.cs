using YK.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace YK.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public string Get()
        {
            return "Api is up and running!";
        }
    }
}