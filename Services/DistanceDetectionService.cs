using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Apz_backend.Interfaces;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Apz_backend.Services
{
    public class DistanceDetectionService : IDistanceDetectionService
    {
        static readonly CascadeClassifier catClassifier = new CascadeClassifier("Helpers/haarcascade_frontalcatface_extended.xml");
        static readonly CascadeClassifier dogClassifier = new CascadeClassifier("Helpers/haarcascade_frontaldogface_alt.xml");
        static private Rectangle[] rectangles { get; set; }
        public async Task<bool> IsAppropriateDistance(Image animalImage, string animalType)
        {
            rectangles = await Task.Run(() => DetectAnimal(animalImage, animalType));

            if (rectangles != null && !IsEmpty(rectangles))
            {
                int maxSize = rectangles.Max(r => r.Size.Height * r.Size.Width);
                int minSize = rectangles.Min(r => r.Size.Height * r.Size.Width);

                Rectangle maxHit = rectangles.FirstOrDefault(r => r.Size.Height * r.Size.Width == maxSize);
                Rectangle minHit = rectangles.FirstOrDefault(r => r.Size.Height * r.Size.Width == minSize);

                double distance = await Task.Run(() => GetDistance(maxHit, minHit));

                if (distance >= MinimumRequiredDistance(minHit))
                {
                    return true;
                }
            }

            return false;
        }

        private static int MinimumRequiredDistance(Rectangle minHit)
        {
            return minHit.Size.Width * minHit.Size.Height;
        }

        private double GetDistance(Rectangle maxHit, Rectangle minHit)
        {
            double distance = (Math.Pow(maxHit.Size.Width, 2) - Math.Pow(minHit.Size.Width, 2)) + (Math.Pow(maxHit.Size.Height, 2) - Math.Pow(minHit.Size.Height, 2));

            return distance;
        }

        private static bool IsEmpty(Rectangle[] rectangles)
        {
            return rectangles.Length <= 0;
        }

        private static Rectangle[] DetectAnimal(Image image, string animalType)
        {
            Rectangle[] detectedRectangles;
            Bitmap bitmap = new Bitmap(image);
            Image<Bgr, byte> grayImage = bitmap.ToImage<Bgr, byte>();

            switch (animalType)
            {
                case "Cat":
                    detectedRectangles = catClassifier.DetectMultiScale(grayImage, 1.4, 0);
                    break;
                case "Dog":
                    detectedRectangles = dogClassifier.DetectMultiScale(grayImage, 1.4, 0);
                    break;
                default:
                    return null;
            }
            
            return detectedRectangles;
        }
    }
}