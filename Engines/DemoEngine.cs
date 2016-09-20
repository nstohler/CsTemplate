using AppConfiguration;
using Data.Repository.Contracts.Repository_Interfaces;
using Engines.Contracts;
using LibLog.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engines
{
	public class DemoEngine : IDemoEngine
	{
		private static readonly ILog _Logger = LogProvider.GetCurrentClassLogger();

		private readonly IAppConfig _AppConfig;
		private readonly ICustomerRepository _CustomerRepository;
		private readonly IOrderRepository _OrderRepository;

		public DemoEngine(IAppConfig appConfig, ICustomerRepository customerRepository, IOrderRepository orderRepository)
		{
			_AppConfig = appConfig;
			_CustomerRepository = customerRepository;
			_OrderRepository = orderRepository;
		}

		public void Execute()
		{
			_Logger.Info("Execute start");

			_Logger.InfoFormat("from AppConfig: {setting}, {value}, {date}", _AppConfig.MySetting, _AppConfig.MyValue, _AppConfig.MyDate.ToShortDateString());

			var customerSet = _CustomerRepository.Get();

			foreach (var customer in customerSet)
			{
				_Logger.InfoFormat("CustomerId: {name} ({id}) - {company}", customer.ContactName, customer.CustomerId, customer.CompanyName);
				var orderSet = _OrderRepository.GetByCustomerId(customer.CustomerId);
				foreach (var order in orderSet)
				{
					_Logger.InfoFormat("  - order ({id}): {quantity}, {date}", order.OrderId, order.OrderQuantity, order.OrderDate);
				}
			}

			_Logger.Info("Execute end");
		}
	}
}
