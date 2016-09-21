using Autofac;
using LibLog.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrapper
{
	internal class HostBootstrapperService
	{
		private static readonly ILog _Logger = LogProvider.GetCurrentClassLogger();
		public IContainer AutofacContainer { get { return _AutofacContainer; } }

		private readonly IContainer _AutofacContainer;

		public HostBootstrapperService()
		{
			_Logger.Info("HostBootstrapperService.CTOR");

			// other initializations go here...

			_AutofacContainer = InitializeAutofacContainer(builder =>
			{
				//AutoMapperConfig.RegisterForDI(builder);
				//QuartzAutofacConfig.RegisterForDI(builder);
			});
		}

		private static IContainer InitializeAutofacContainer(Action<ContainerBuilder> containerBuilderFn)
		{
			return AutofacLoader.Initialize(containerBuilderFn);
		}
	}
}
