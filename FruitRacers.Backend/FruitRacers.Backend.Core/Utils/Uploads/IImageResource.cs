using System.IO;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Utils.Uploads
{
    public interface IImageResource
    {
        Task Store(Stream imageStream);

        Task Delete();
    }
}