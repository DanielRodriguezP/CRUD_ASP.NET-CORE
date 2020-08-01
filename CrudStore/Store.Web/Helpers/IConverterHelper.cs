using Store.Web.Data.Entities;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Product> ToProductAsync(ProductViewModel model, string path, bool isNew);

        ProductViewModel ToProductViewModel(Product product);
    }
}
