using Store.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync() {
            await _context.Database.EnsureCreatedAsync();
            await CheckStoreAsync();
            await CheckProductAsync();
        }

        private async Task CheckStoreAsync()
        {
            if (!_context.Stores.Any())
            {
                _context.Stores.Add(new Stores { StoreName = "La Vaquita", OpeningDate = DateTime.Now.AddYears(-2) });
                _context.Stores.Add(new Stores { StoreName = "D1", OpeningDate = DateTime.Now.AddYears(-2) });
                _context.Stores.Add(new Stores { StoreName = "Surtimax", OpeningDate = DateTime.Now.AddYears(-2) });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckProductAsync()
        {
            var store = _context.Stores.FirstOrDefault();
            if (!_context.Products.Any())
            {
                AddProduct("Salchicha","432KSX","Salchicha ranchera",3400,"/image", store);
                AddProduct("Margarita", "346DSA", "Papas de pollo", 1400, "/image", store);
                AddProduct("Vino", "783JKG", "Vino tinto", 20400, "/image", store);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string productName, string sku, string description, int value, string image, Stores store)
        {
            _context.Products.Add(new Product
            {
                ProductName = productName,
                SKU = sku,
                Description = description,
                Value = value,
                ImageUrl = image,
                Store = store
            });
        }
    }
}
