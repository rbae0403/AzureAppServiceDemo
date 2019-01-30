using System.Web.Http;

namespace DemoWebAPI.Controllers
{
    /// <summary>
    /// DemoController
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class DemoController : ApiController
    {
        /// <summary>
        /// Gets the demo.
        /// </summary>
        /// <returns>
        /// IHttpActionResult
        /// </returns>
        [HttpGet]
        [Route("Demo")]
        public IHttpActionResult GetDemo()
        {
            return this.Ok("Hello World!");
        }
    }
}