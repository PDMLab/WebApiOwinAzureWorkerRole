using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Microsoft.Owin.Hosting;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WebApiOwinAzureWorkerRole {
	public class WorkerRole : RoleEntryPoint {
		IDisposable _server;

		public override void Run() {
			// This is a sample worker implementation. Replace with your logic.
			Trace.TraceInformation("WebApiOwinAzureWorkerRole entry point called", "Information");

			while(true) {
				Thread.Sleep(10000);
				Trace.TraceInformation("Working", "Information");
			}
		}

		public override bool OnStart() {
			// Set the maximum number of concurrent connections 
			ServicePointManager.DefaultConnectionLimit = 12;

			// For information on handling configuration changes
			// see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

			var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["HTTP"];
			var baseUri = string.Format("{0}://{1}", endpoint.Protocol, endpoint.IPEndpoint);

			_server = WebApp.Start<Startup>(new StartOptions(url: baseUri));

			return base.OnStart();
		}

		public override void OnStop() {
			if(null != _server) {
				_server.Dispose();
			}
			base.OnStop();
		}
	}
}