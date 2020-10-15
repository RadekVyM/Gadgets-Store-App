using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using GadgetStoreApp.Core;
using System;

namespace GadgetStoreApp
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            InitializeComponent();

            Device.SetFlags(new string[] { "Shapes_Experimental" } );

            var services = new ServiceCollection();

            services.AddSingleton<IProductsManager, ProductsManager>();
            services.AddSingleton<ICartManager, CartManager>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddTransient<IHomePageViewModel, HomePageViewModel>();
            services.AddTransient<IProductDetailPageViewModel, ProductDetailPageViewModel>();
            services.AddTransient<IBasePageViewModel, BasePageViewModel>();

            ServiceProvider = services.BuildServiceProvider();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
