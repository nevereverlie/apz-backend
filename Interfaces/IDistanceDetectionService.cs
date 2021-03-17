using System.Threading.Tasks;
using System.Drawing;

namespace Apz_backend.Interfaces
{
    public interface IDistanceDetectionService
    {
        Task<bool> IsAppropriateDistance(Image animalImage, string animalType);
    }
}