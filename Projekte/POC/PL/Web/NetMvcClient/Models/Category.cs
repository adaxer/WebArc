using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetMvcClient.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required, StringLength(30)]
        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}