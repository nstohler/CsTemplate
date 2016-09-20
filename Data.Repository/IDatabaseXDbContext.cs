// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

namespace Data.Repository
{
    using Data.Model;

    public interface IDatabaseXDbContext : System.IDisposable
    {
        System.Data.Entity.DbSet<Customer> Customer { get; set; } // Customer
        System.Data.Entity.DbSet<Order> Order { get; set; } // Order
        System.Data.Entity.DbSet<Sysdiagrams> Sysdiagrams { get; set; } // sysdiagrams

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
    }

}
// </auto-generated>
