using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class ProductViewModel : Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Store Id")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a pet type.")]
        public int StoreId { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; } 

        //Combobox
        public IEnumerable<SelectListItem> Stores { get; set; }
    }
}
