using System.Web.Http;
using Owin;

namespace WebApiOwinAzureWorkerRole {
	internal class Startup {
		public void Configuration(IAppBuilder app) {
			var config = new HttpConfiguration();
			config.Routes.MapHttpRoute(
				"API Default",
				"api/{controller}/{id}",
				new { id = RouteParameter.Optional });

			app.UseWebApi(config);
		}
	}
}