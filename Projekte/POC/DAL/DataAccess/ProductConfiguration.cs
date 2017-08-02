// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Southwind.DataAccess
{
    using Southwind.Models;

    // Products
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.32.0.0")]
    public partial class ProductConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
            : this("dbo")
        {
        }

        public ProductConfiguration(string schema)
        {
            Property(x => x.SupplierId).IsOptional();
            Property(x => x.CategoryId).IsOptional();
            Property(x => x.QuantityPerUnit).IsOptional();
            Property(x => x.UnitPrice).IsOptional().HasPrecision(19,4);
            Property(x => x.UnitsInStock).IsOptional();
            Property(x => x.UnitsOnOrder).IsOptional();
            Property(x => x.ReorderLevel).IsOptional();

            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
