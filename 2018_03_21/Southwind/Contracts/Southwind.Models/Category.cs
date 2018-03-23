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

    // Categories
    [Table("Categories", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.36.1.0")]
    public partial class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"CategoryID", Order = 1, TypeName = "int")]
        [Index(@"PK_Categories", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; } // CategoryID (Primary key)

        [Column(@"CategoryName", Order = 2, TypeName = "nvarchar")]
        [Index(@"CategoryName", 1, IsUnique = false, IsClustered = false)]
        [Required]
        [MaxLength(15)]
        [StringLength(15)]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; } // CategoryName (length: 15)

        [Column(@"Description", Order = 3, TypeName = "ntext")]
        [MaxLength]
        [Display(Name = "Description")]
        public string Description { get; set; } // Description (length: 1073741823)

        [Column(@"Picture", Order = 4, TypeName = "image")]
        [MaxLength(2147483647)]
        [Display(Name = "Picture")]
        public byte[] Picture { get; set; } // Picture (length: 2147483647)

        // Reverse navigation

        /// <summary>
        /// Child Products where [Products].[CategoryID] point to this entity (FK_Products_Categories)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Product> Products { get; set; } // Products.FK_Products_Categories

        public Category()
        {
            Products = new System.Collections.Generic.List<Product>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>