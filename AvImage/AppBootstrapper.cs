
namespace AvImage
{
    using System.Windows;
    using UI;
    using Caliburn.Micro;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    public class AppBootstrapper : BootstrapperBase
    {
        private WindsorContainer container;
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            base.Configure();
            this.container = new WindsorContainer();

            this.container.Register(
                Component.For<IWindowManager>().ImplementedBy<WindowManager>().LifestyleSingleton(),
                Component.For<IEventAggregator>().ImplementedBy<EventAggregator>().LifestyleSingleton(),
                Component.For<IWindsorContainer>().Instance(this.container).LifestyleSingleton(),
                Component.For<AppBootstrapper>().Instance(this).LifestyleSingleton());
            

            this.container.Register(
                Classes.FromThisAssembly()
                .Where(c => c.Name.EndsWith("ViewModel"))
                .WithServiceAllInterfaces()
                .WithServiceSelf()
                .LifestyleTransient());
            
            this.container.Register(
                Classes.FromThisAssembly()
                    .Where(c => c.Name.EndsWith("View"))
                    .WithServiceSelf()
                    .LifestyleTransient());
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return this.container.ResolveAll(service).Cast<object>();
        }

        protected override object GetInstance(Type service, string key)
        {
             return this.container.Resolve(service);
        }
    }
}
