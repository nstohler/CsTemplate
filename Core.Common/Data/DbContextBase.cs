using Core.Common.Util;

namespace Core.Common.Data
{
	public class DbContextBase : System.Data.Entity.DbContext
	{
		static DbContextBase()
		{
			StaticRefUtil.EnsureStaticReference<System.Data.Entity.SqlServer.SqlProviderServices>();
		}
		protected DbContextBase()
		{

		}
		protected DbContextBase(System.Data.Entity.Infrastructure.DbCompiledModel model)
			: base(model)
		{

		}
		public DbContextBase(string nameOrConnectionString)
			: base(nameOrConnectionString)
		{

		}
		public DbContextBase(string nameOrConnectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
			: base(nameOrConnectionString, model)
		{

		}
		public DbContextBase(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
			: base(existingConnection, contextOwnsConnection)
		{

		}
		public DbContextBase(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
			: base(existingConnection, model, contextOwnsConnection)
		{

		}
		public DbContextBase(System.Data.Entity.Core.Objects.ObjectContext objectContext, bool dbContextOwnsObjectContext)
			: base(objectContext, dbContextOwnsObjectContext)
		{

		}

	}
}
