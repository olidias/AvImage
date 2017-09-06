using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace AvImage.UI.ImagesContainer
{
    public class ImagesContainerViewModel : Screen, ILayoutViewModel
    {
        public ImagesContainerViewModel()
        {
            Console.WriteLine("ImagesContainerVM instantiated");
        }
        
        public override string DisplayName { get; set; }
    }
}
