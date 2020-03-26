using System.IO;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils.Uploads
{
    public interface IImageResource
    {
        Task Store(Stream imageStream);

        Task Delete();
    }
}