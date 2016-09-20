using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;
using System.Data.Entity;

namespace SampleDatabaseWalkthrough
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
				using (var context = new Data.Repository.DatabaseXDbContext())
				{
					var customerSet = from c in context.Customer
									  .Include(c => c.Order)
									  select c;

					foreach (var customer in customerSet)
					{
						Console.WriteLine("Customer: {0} - {1}; orders: {2}", customer.CompanyName, customer.ContactName, customer.Order.Count());
						foreach (var order in customer.Order)
						{
							Console.WriteLine("  Order {0}: {1} {2}", order.OrderId, order.OrderQuantity, order.OrderDate.Value.ToShortDateString());
						}
						

						//Console.WriteLine("  Customer: {0}", customer.Dump());

						////Console.WriteLine("order count = {0}", customer.Orders.Count());
						//customer.Orders.ToList().ForEach(x => x.PrintDump());
					}
				}
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
                throw;
            }

        }
    }
}
