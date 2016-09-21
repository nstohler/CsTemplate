using Core.Common.Contracts;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Contracts.Repository_Interfaces
{
	public interface ICustomerRepository : IDataRepository<Customer>
	{
		IEnumerable<Customer> GetByCompanyName(string companyName);

		Customer GetWithOrders(int id);
	}
}
