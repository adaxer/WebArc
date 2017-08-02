using System.ComponentModel.DataAnnotations;

namespace Southwind.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required, StringLength(30)]
        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}