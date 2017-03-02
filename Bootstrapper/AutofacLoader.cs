using AppConfiguration;
using Autofac;
using Core.Common.Data;
using Core.Common.Data.Contracts;
using Data.Repository;
using Data.Repository.Contracts;
using Data.Repository.Data_Repositories;
using Engines;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrapper
{
	public static class AutofacLoader
	{
		public static IContainer Initialize(Action<ContainerBuilder> containerBuilderFn)
		{
			IContainer container = null;
			ContainerBuilder builder = new ContainerBuilder();

			// register types here

			// EF Repositories
			builder.RegisterAssemblyTypes(typeof(CustomerRepository).Assembly)
				.Where(t => t.Name.EndsWith("Repository"))
				.As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

			builder.RegisterAssemblyTypes(typeof(DemoEngine).Assembly)
				.Where(t => t.Name.EndsWith("Engine"))
				.As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

			builder.RegisterGeneric(typeof(GenericRepository<>))
				.As(typeof(IGenericRepository<>))
				//.WithParameter(new TypedParameter(typeof(DbContext), new TestDbContext()))	// DEMO!
				;   // interface!
					//.AsSelf();

			builder.RegisterType<DatabaseXDbContext>().As<DbContext>().InstancePerLifetimeScope();

			builder.RegisterType<DemoClass>().AsSelf();
			builder.RegisterType<TestDbContext>().AsSelf();

			builder.RegisterType<DataRepositoryFactory>().As<IDataRepositoryFactory>();

			builder.RegisterType<AppConfig>().As<IAppConfig>();

			// invoke containerBuilderFn if provided
			containerBuilderFn?.Invoke(builder);

			container = builder.Build();

			return container;
		}
	}
}
