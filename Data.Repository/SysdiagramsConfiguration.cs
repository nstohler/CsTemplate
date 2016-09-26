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

    // sysdiagrams
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class SysdiagramsConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Sysdiagrams>
    {
        public SysdiagramsConfiguration()
            : this("dbo")
        {
        }

        public SysdiagramsConfiguration(string schema)
        {
            ToTable("sysdiagrams", schema);
            HasKey(x => x.DiagramId);

            Property(x => x.Name).HasColumnName(@"name").IsRequired().HasColumnType("nvarchar").HasMaxLength(128);
            Property(x => x.PrincipalId).HasColumnName(@"principal_id").IsRequired().HasColumnType("int");
            Property(x => x.DiagramId).HasColumnName(@"diagram_id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Version).HasColumnName(@"version").IsOptional().HasColumnType("int");
            Property(x => x.Definition).HasColumnName(@"definition").IsOptional().HasColumnType("varbinary");
        }
    }

}
// </auto-generated>
