// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Southwind.Models
{

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.36.1.0")]
    public partial class EmployeeSalesByCountryReturnModel
    {
        public System.String Country { get; set; }
        public System.String LastName { get; set; }
        public System.String FirstName { get; set; }
        public System.DateTime? ShippedDate { get; set; }
        public System.Int32 OrderID { get; set; }
        public System.Decimal? SaleAmount { get; set; }
    }

}
// </auto-generated>
