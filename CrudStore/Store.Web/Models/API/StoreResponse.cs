using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models.API
{
    public class StoreResponse
    {
        [Required]
        public int Id { get; set; }

       public string StoreName { get; set; }

        public DateTime OpeningDate { get; set; }

        public ICollection<ProductResponse> Products { get; set; }

    }
}
