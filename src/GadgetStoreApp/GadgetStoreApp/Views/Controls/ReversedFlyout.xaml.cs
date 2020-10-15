using GadgetStoreApp.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GadgetStoreApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReversedFlyout : ContentView
    {
        double imageScale => 0.8d;
        double imageTranslation => Width * (14d / 20d);

        public bool IsOpen { get; set; }
        public List<Item> Items { get; set; }

        public ReversedFlyout()
        {
            Items = new List<Item>();

            Items.Add(new Item { PageEnum = PageEnum.HomePage, IconPath = App.Current.Resources.GetValue<string>("HomePath"), Text = "Home", IsRelative = false });
            Items.Add(new Item { PageEnum = PageEnum.ProfilePage, IconPath = App.Current.Resources.GetValue<string>("ProfilePath"), Text = "Profile" });
            Items.Add(new Item { PageEnum = PageEnum.BalancePage, IconPath = App.Current.Resources.GetValue<string>("BalancePath"), Text = "Balance" });
            Items.Add(new Item { PageEnum = PageEnum.CartPage, IconPath = App.Current.Resources.GetValue<string>("CartPath"), Text = "Cart" });
            Items.Add(new Item { PageEnum = PageEnum.FavoritesPage, IconPath = App.Current.Resources.GetValue<string>("FavoritesPath"), Text = "Favorites" });
            Items.Add(new Item { PageEnum = PageEnum.HelpPage, IconPath = App.Current.Resources.GetValue<string>("HelpPath"), Text = "Help" });
            Items.Add(new Item { PageEnum = PageEnum.SettingsPage, IconPath = App.Current.Resources.GetValue<string>("SettingsPath"), Text = "Settings" });

            InitializeComponent();

            SizeChanged += ReversedFlyoutSizeChanged;
        }

        public async Task OpenAsync()
        {
            IsOpen = true;

            imageFrame.TranslationX = 0;
            imageFrame.TranslationY = 0;
            imageFrame.WidthRequest = Width;
            imageFrame.HeightRequest = Height;

            var imageBytes = DependencyService.Get<IScreenshotService>().MakeScreenShot();
            var source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            image.Source = source;

            somethingInBackground.IsVisible = false;
            contentGrid.IsVisible = false;
            backgroundBoxView.IsVisible = false;
            IsVisible = true;

            Opacity = 0;
            await this.FadeTo(1, 120);
            Opacity = 1;

            somethingInBackground.IsVisible = true;
            contentGrid.IsVisible = true;
            backgroundBoxView.IsVisible = true;

            DependencyService.Get<IStatusBarService>().SetLightStatusBar(false);

            await imageFrame.LayoutTo(new Rectangle(imageTranslation, (Height - (Height * imageScale)) / 2, Width * imageScale, Height * imageScale));
        }

        public async Task CloseAsync()
        {
            IsOpen = false;

            await imageFrame.LayoutTo(new Rectangle(0, 0, Width, Height));

            await this.FadeTo(0, 150);

            IsVisible = false;

            imageFrame.TranslationX = 0;
            imageFrame.TranslationY = 0;
            imageFrame.WidthRequest = Width;
            imageFrame.HeightRequest = Height;

            ((AppShell)Shell.Current).UpdateStatusBarColour();
        }

        private async void CloseTapped(object sender, EventArgs e)
        {
            await CloseAsync();
        }

        private void ReversedFlyoutSizeChanged(object sender, EventArgs e)
        {
            somethingInBackground.TranslationX = Width * (12d / 20d);
            somethingInBackground.WidthRequest = Width * 0.7d;
            somethingInBackground.HeightRequest = Height * 0.7d;

            lineBoxView.WidthRequest = Width * (12d / 20d) - 38;
            innerContentGrid.HeightRequest = (Height * imageScale) - crossSvg.Height;
            innerContentGrid.Margin = new Thickness(innerContentGrid.Margin.Left, ((Height - innerContentGrid.HeightRequest) / 2) - crossSvg.Height - crossSvg.Margin.VerticalThickness - StatusBar.Height, 0, 0);
        }

        private async void ItemTapped(object sender, EventArgs e)
        {
            Item item = (sender as BindableObject).BindingContext as Item;

            if(item.PageEnum != Shell.Current.GetCurrentPage())
                _ = Shell.Current.GoToAsync((item.IsRelative ? "" : "///") + item.PageEnum.ToString());

            await CloseAsync();
        }
    }

    public class Item
    {
        public string IconPath { get; set; }
        public string Text { get; set; }
        public PageEnum PageEnum { get; set; }
        public bool IsRelative { get; set; } = true;
    }
}