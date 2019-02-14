using System.Web.Http;

namespace DemoAzureBlob.Controllers
{
    /// <summary>
    /// DemoController
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class DemoController : ApiController
    {
        /// <summary>
        /// Uploads the image file.
        /// </summary>
        /// <returns>
        /// image url
        /// </returns>
        [HttpPost]
        [Route("image")]
        public IHttpActionResult UploadImageFile()
        {
            return this.Ok();
        }
    }
}