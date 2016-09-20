using EcConfig.Core;
using EnsureThat;
using LibLog.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfiguration
{
	public class AppConfig : IAppConfig
	{
		private static readonly ILog _Logger = LogProvider.GetCurrentClassLogger();

		public AppConfig()
		{
			_Logger.Info("Reading AppConfig (default.config)...");

			MySetting = Config.Get("MySetting");
			Ensure.That(MySetting, "MySetting").IsNotNullOrWhiteSpace();

			MyValue = Convert.ToInt32(Config.Get("MyValue"));

			MyDate = Convert.ToDateTime(Config.Get("MyDate"));

			_Logger.DebugFormat("AppConfig ready! {@this}", this);
		}

		public string MySetting { get; private set; }
		public int MyValue { get; private set; }
		public DateTime MyDate { get; private set; }
	}
}
