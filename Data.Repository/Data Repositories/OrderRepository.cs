using Data.Repository.Contracts.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Common.Extensions;

namespace Data.Repository.Data_Repositories
{
	public class OrderRepository : IOrderRepository
	{
		public IEnumerable<Order> Get()
		{
			using (var context = new DatabaseXDbContext())
			{
				var query = from o in context.Order
							select o;

				return query.ToFullyLoaded();
			}
		}

		public Order Get(int id)
		{
			using (var context = new DatabaseXDbContext())
			{
				var query = from o in context.Order
							where o.OrderId == id
							select o;

				return query.SingleOrDefault();
			}
		}

		public IEnumerable<Order> GetByCustomerId(int customerId)
		{
			using (var context = new DatabaseXDbContext())
			{
				var query = from o in context.Order
							where o.CustomerId == customerId
							select o;

				return query.ToFullyLoaded();
			}
		}
	}
}
