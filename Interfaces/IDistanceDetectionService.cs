using System.Threading.Tasks;
using System.Drawing;

namespace Apz_backend.Interfaces
{
    public interface IFaceDetectionService
    {
        bool IsAppropriateDistance(Image image, int userId);
    }
}