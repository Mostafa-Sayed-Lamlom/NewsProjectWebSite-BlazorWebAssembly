using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        [MinLength(3, ErrorMessage ="at least 20 characters required")]
        public string CategoryName { get; set; }
        //[Compare("CategoryName", ErrorMessage ="Name not matched")]
        //public string ConfirmeCategoryName { get; set; }
    }
}
