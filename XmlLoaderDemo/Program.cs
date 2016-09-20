using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ServiceStack.Text;
using Data.Model;

namespace XmlLoaderDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			XDocument doc = XDocument.Load("MyData.xml");

			var customerSet = from c in doc.Descendants("Customer")
							  select new Customer
							  {
								  CustomerId = (int)c.Attribute("CustomerId"),
								  CompanyName = (string)c.Attribute("CompanyName"),
								  ContactName = (string)c.Attribute("ContactName"),
								  Phone = (string)c.Attribute("Phone"),

								  Order = (from o in doc.Descendants("Order")
											where (int)o.Attribute("CustomerId") == (int)c.Attribute("CustomerId")
											select new Order
											{
												OrderId = (int)o.Attribute("OrderId"),
												CustomerId = (int)o.Attribute("CustomerId"),
												OrderDate = ParseXmlDate(o.Attribute("OrderDate")),
												OrderQuantity = ParseXmlInt(o.Attribute("OrderQuantity")),
											})
										   .ToList(),
							  };

			foreach (var customer in customerSet)
			{
				//Console.WriteLine("Customer {0}: {1}, {2}", customer.CustomerId, customer.CompanyName, customer.ContactName);
				customer.PrintDump();
			}
		}

		private static DateTime? ParseXmlDate(XAttribute attribute)
		{
			if (attribute == null || string.IsNullOrWhiteSpace(attribute.Value))
				return null;

			DateTime date;
			if (DateTime.TryParse(attribute.Value, out date))
				return date;

			return null;
		}

		private static int? ParseXmlInt(XAttribute attribute)
		{
			if (attribute == null || string.IsNullOrWhiteSpace(attribute.Value))
				return null;

			int data;
			if (Int32.TryParse(attribute.Value, out data))
				return data;

			return null;
		}
	}
}
