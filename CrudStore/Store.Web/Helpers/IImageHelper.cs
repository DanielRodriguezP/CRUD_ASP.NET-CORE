using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Store.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile);
    }
}