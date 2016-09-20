using Autofac;
using LibLog.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bootstrapper
{
	public static class HostBooststrapper
	{
		private static readonly ILog _Logger = LogProvider.GetCurrentClassLogger();

		private readonly static Lazy<HostBootstrapperService> _HostBootstrapperService = new Lazy<HostBootstrapperService>(Initialize);

		private static HostBootstrapperService Initialize()
		{
			var hostBootstrapperService = new HostBootstrapperService();
			return hostBootstrapperService;
		}

		public static IContainer AutofacContainer
		{
			get
			{
				return _HostBootstrapperService.Value.AutofacContainer;
			}
		}	
	}
}
