using GadgetStoreApp.Core;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GadgetStoreApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public string LogoImageName { get; set; }

        public ProfilePage()
        {
            LogoImageName = "logo.png";

            InitializeComponent();

            BindingContext = ((App)App.Current).ServiceProvider.GetRequiredService<IBasePageViewModel>();
        }
    }
}