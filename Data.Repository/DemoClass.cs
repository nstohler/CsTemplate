using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
	public class DemoClass
	{
		private readonly TestDbContext _context;
		public DemoClass(TestDbContext context)
		{
			_context = context;
		}

		public void DoSomething()
		{
			Console.WriteLine("doing something stupid here...");
		}
	}
}
