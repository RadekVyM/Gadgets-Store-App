using GadgetStoreApp.Core;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GadgetStoreApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BalancePage : ContentPage
    {
        public string LogoImageName { get; set; }

        public BalancePage()
        {
            LogoImageName = "logo.png";

            InitializeComponent();

            BindingContext = ((App)App.Current).ServiceProvider.GetRequiredService<IBasePageViewModel>();
        }
    }
}