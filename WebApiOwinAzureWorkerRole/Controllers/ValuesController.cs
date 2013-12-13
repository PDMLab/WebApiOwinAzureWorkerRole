using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiOwinAzureWorkerRole.Controllers {
	public class ValuesController : ApiController {
		public HttpResponseMessage Get() {
			return Request.CreateResponse(HttpStatusCode.OK, new[] { 1, 2, 3, 4 });
		}
	}
}