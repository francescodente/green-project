using FruitRacers.Backend.Core.Utils.Uploads;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer.Utils
{
    public static class FormFileExtensions
    {
        public static Task CopyToAsync(this IFormFile formFile, IImageResource imageResource)
        {
            using (Stream imageStream = formFile.OpenReadStream())
            {
                return imageResource.Store(imageStream);
            }
        }
    }
}
