using Store.Web.Data;
using Store.Web.Data.Entities;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;

        public ConverterHelper(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public async Task<Product> ToProductAsync(ProductViewModel model, string path, bool isNew)
        {
            var product = new Product
            {
                Id = isNew ? 0 : model.Id,
                SKU = model.SKU,
                ProductName = model.ProductName,
                Value = model.Value,
                Description = model.Description,
                ImageUrl = path,
                Store = await _dataContext.Stores.FindAsync(model.StoreId),
                
            };
           
            return product;
        }

        public ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                ProductId = product.Id,
                SKU = product.SKU,
                ProductName = product.ProductName,
                Value = product.Value,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                StoreId = product.Store.Id                
            };
        }
    }
}
