using Data.Repository.Contracts.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Core.Common.Extensions;
using System.Data.Entity;

namespace Data.Repository.Data_Repositories
{
	public class CustomerRepository : DataRepositoryBase<Customer>, ICustomerRepository
	{
		public IEnumerable<Customer> GetByCompanyName(string companyName)
		{
			using (var context = new DatabaseXDbContext())
			{
				var query = from c in context.Customer.AsNoTracking()
							where c.CompanyName.Equals(companyName, StringComparison.CurrentCultureIgnoreCase)
							select c;

				return query.ToFullyLoaded();
			}
		}

		public Customer GetWithOrders(int id)
		{
			using (var context = new DatabaseXDbContext())
			{
				var query = from c in context.Customer.AsNoTracking()
							.Include(c => c.Order)
							where c.CustomerId == id
							select c;

				return query.SingleOrDefault();
			}
		}

		protected override Customer AddEntity(DatabaseXDbContext entityContext, Customer entity)
		{
			return entityContext.Customer.Add(entity);
		}

		protected override IEnumerable<Customer> GetEntities(DatabaseXDbContext entityContext)
		{
			return GetEntitiesQueryable(entityContext);
		}

		protected override Customer GetEntity(DatabaseXDbContext entityContext, int id)
		{
			var query = from o in entityContext.Customer.AsNoTracking()
						where o.CustomerId == id
						select o;

			return query.SingleOrDefault();
		}

		protected override Customer UpdateEntity(DatabaseXDbContext entityContext, Customer entity)
		{
			return (from o in entityContext.Customer
					where o.CustomerId == entity.CustomerId
					select o).SingleOrDefault();
		}

		protected IEnumerable<Customer> GetEntitiesQueryable(DatabaseXDbContext entityContext)
		{
			return from c in entityContext.Customer.AsNoTracking()
				   select c;
		}
	}
}
