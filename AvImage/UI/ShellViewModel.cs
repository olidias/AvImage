using System;

namespace AvImage.UI
{
    using AvImage.UI.ImagesContainer;
    using Caliburn.Micro;
    public class ShellViewModel : Conductor<ILayoutViewModel>
    {
        private ImagesContainerViewModel imagesContainerViewModel;

        public ShellViewModel(ImagesContainerViewModel imagesContainerViewModel)
        {
            this.imagesContainerViewModel = imagesContainerViewModel;
            ActivateItem(this.imagesContainerViewModel);
        }
        
    }
}
