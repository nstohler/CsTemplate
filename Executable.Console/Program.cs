using Autofac;
using Data.Repository.Contracts;
using LibLog.Common.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;
using Data.Repository.Contracts.Repository_Interfaces;
using Engines.Contracts;

namespace Executable.Console
{
	class Program
	{
		private static ILog _Logger;

		static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.Destructure.ByTransforming<System.IO.FileInfo>(f => new { Name = f.Name, Full = f.FullName, Exists = f.Exists, Attributes = f.Attributes })
				.MinimumLevel.Verbose()
				.WriteTo.LiterateConsole(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
				.WriteTo.RollingFile("logs\\myApp-{Date}.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose)
				.CreateLogger();

			Log.Information("App Startup (Serilog Log.Information)");

			_Logger = LogProvider.GetCurrentClassLogger();
			_Logger.Info("Startup (via LibLog interface)");

			var autofacContainer = Bootstrapper.HostBooststrapper.AutofacContainer;

			try
			{
				using (var scope = autofacContainer.BeginLifetimeScope())
				{
					var demoEngine = scope.Resolve<IDemoEngine>();
					Ensure.That(demoEngine, "demoEngine").IsNotNull();

					demoEngine.Execute();
				}
			}
			catch (Exception ex)
			{
				_Logger.ErrorException("Error", ex);
			}

		}
	}
}
