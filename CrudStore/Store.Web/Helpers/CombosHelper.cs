using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace Store.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboStores()
        {
            var list = _dataContext.Stores.Select(st => new SelectListItem
            {
                Text = st.StoreName,
                Value = $"{st.Id}"
            })
            .OrderBy(st => st.Text)
            .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a store]",
                Value = "0"
            });
            
            return list;
        }
    }
}
