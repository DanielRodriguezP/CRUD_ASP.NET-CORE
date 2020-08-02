using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Web.Data;
using Store.Web.Models.API;

namespace Store.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<IndexModel> _logger;

        public ProductsController(DataContext dataContext, ILogger<IndexModel> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        
        [HttpGet("{id}")] // api/Products/{id}
        public async Task<IActionResult> GetProductAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var store = await _dataContext.Stores
              .Include(p => p.Products)
              .FirstOrDefaultAsync(p => p.Id == id);

            if (store == null)
            {
                return NotFound();
            }

            var response = new StoreResponse
            {
                Id = store.Id,
                StoreName = store.StoreName,
                OpeningDate = store.DateLocal,
                Products = store.Products.Select(p => new ProductResponse
                {
                    Id = p.Id,
                    SKU = p.SKU,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Value = p.Value,
                    ImageUrl = p.ImageUrl
                }).ToList()
            };

            _logger.LogInformation("Get");

            return Ok(response);
        }
    }
}