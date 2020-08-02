using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models.API
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string SKU { get; set; }

        public string Description { get; set; }

        public int Value { get; set; }

        public string ImageUrl { get; set; }
    }
}
