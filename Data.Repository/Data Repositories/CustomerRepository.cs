using Data.Repository.Contracts.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Common.Extensions;
using System.Data.Entity;

namespace Data.Repository.Data_Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		public IEnumerable<Customer> Get()
		{
			using (var context = new DatabaseXDbContext())
			{
				var query = from c in context.Customer
							select c;

				return query.ToFullyLoaded();
			}
		}

		public IEnumerable<Customer> GetByCompanyName(string companyName)
		{
			using (var context = new DatabaseXDbContext())
			{
				var query = from c in context.Customer
							where c.CompanyName.Equals(companyName, StringComparison.CurrentCultureIgnoreCase)
							select c;

				return query.ToFullyLoaded();
			}
		}

		public Customer Get(int id)
		{
			using (var context = new DatabaseXDbContext())
			{
				var query = from c in context.Customer
							where c.CustomerId == id
							select c;

				return query.SingleOrDefault();
			}
		}

		public Customer GetWithOrders(int id)
		{
			using (var context = new DatabaseXDbContext())
			{
				var query = from c in context.Customer
							.Include(c => c.Order)
							where c.CustomerId == id
							select c;

				return query.SingleOrDefault();
			}
		}

		// TODO: base class with GET/ADD/UPDATE methods
	}
}
