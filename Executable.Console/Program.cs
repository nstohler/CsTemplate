using Autofac;
using LibLog.Common.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;
using Engines.Contracts;

namespace Executable.Console
{
	class Program
	{
		private static ILog _Logger;

		static void Main(string[] args)
		{
			InitializeLogger();

			SetupDataDirectory();

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
				throw;
			}

		}

		private static void SetupDataDirectory()
		{
			// set up DataDirectory in AppDomain for use in app.config connection string
			// app.config: "...AttachDbFilename=|DataDirectory|\DatabaseX.mdf..."
			string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string path = (System.IO.Path.GetDirectoryName(executable));

			// navigate up 3 directories, point to Data dir where db resides
			path = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"..\..\..\Data"));

			AppDomain.CurrentDomain.SetData("DataDirectory", path);

			_Logger.InfoFormat("AppDomain.DataDirectory: {path}", path);
		}

		private static void InitializeLogger()
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
		}
	}
}
