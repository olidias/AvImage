using System;
using AvImage.AverageCalculation;
using AvImage.ImageProcessing;
using Caliburn.Micro;

namespace AvImage.UI.ImagesContainer
{
    public class ImagesContainerViewModel : Screen, ILayoutViewModel
    {
        public ImagesContainerViewModel()
        {
            Console.WriteLine("ImagesContainerVM instantiated");
            var ife = new ImageFileExtractor(@"E:\Media\Images\CH\Davos\IMG_9498.JPG");
            var calc = new SimpleAverageCalculator(ife.RgbValues);
        }
        
        public override string DisplayName { get; set; }
    }
}
