using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Contracts
{
	public interface IDataRepositoryFactory
	{
		T GetDataRepository<T>() where T : IDataRepository;
	}
}
