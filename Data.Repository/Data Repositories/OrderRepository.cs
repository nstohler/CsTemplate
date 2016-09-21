using Data.Repository.Contracts.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Core.Common.Extensions;

namespace Data.Repository.Data_Repositories
{
	public class OrderRepository : DataRepositoryBase<Order>, IOrderRepository
	{
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

		protected override Order AddEntity(DatabaseXDbContext entityContext, Order entity)
		{
			return entityContext.Order.Add(entity);
		}

		protected override IEnumerable<Order> GetEntities(DatabaseXDbContext entityContext)
		{
			return GetEntitiesQueryable(entityContext);
		}
		

		protected override Order GetEntity(DatabaseXDbContext entityContext, int id)
		{
			var query = from o in entityContext.Order
						where o.OrderId == id
						select o;

			return query.SingleOrDefault();
		}

		protected override Order UpdateEntity(DatabaseXDbContext entityContext, Order entity)
		{
			return (from o in entityContext.Order
					where o.OrderId == entity.OrderId
					select o).SingleOrDefault();
		}

		protected IEnumerable<Order> GetEntitiesQueryable(DatabaseXDbContext entityContext)
		{
			return from o in entityContext.Order
				   select o;
		}
	}
}
