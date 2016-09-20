using Autofac;
using Data.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
	public class DataRepositoryFactory : IDataRepositoryFactory
	{
		IComponentContext _ComponentContext;

		public DataRepositoryFactory(IComponentContext componentContext)
		{
			_ComponentContext = componentContext;
		}

		T IDataRepositoryFactory.GetDataRepository<T>()
		{
			return _ComponentContext.Resolve<T>();
		}
	}
}
