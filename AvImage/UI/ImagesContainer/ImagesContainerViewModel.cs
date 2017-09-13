﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvImage.ImageProcessing;
using Caliburn.Micro;

namespace AvImage.UI.ImagesContainer
{
    public class ImagesContainerViewModel : Screen, ILayoutViewModel
    {
        public ImagesContainerViewModel()
        {
            Console.WriteLine("ImagesContainerVM instantiated");
            var ife = new ImageFileExtractor(@"E:\Media\Images\CH\Bachtel\IMG_8696.JPG");
        }
        
        public override string DisplayName { get; set; }
    }
}
