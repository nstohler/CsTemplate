using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Contracts.Repository_Interfaces
{
	public interface IOrderRepository : IDataRepository<Order>
	{
		Order Get(int id);
		IEnumerable<Order> Get();
		IEnumerable<Order> GetByCustomerId(int customerId);
	}
}
