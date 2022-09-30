using GadgetStoreApp.Core;
using GadgetStoreApp.Maui.Extensions;
using GadgetStoreApp.Maui.Views.Pages;
using Microsoft.Maui.Controls.Shapes;
using SimpleToolkit.Core;

namespace GadgetStoreApp.Maui
{
    public partial class AppShell : SimpleToolkit.SimpleShell.SimpleShell
    {
        private const string OpenMenuAnimationKey = "OpenMenuAnimation";
        private const string CloseMenuAnimationKey = "CloseMenuAnimation";
        private const double OpenScale = 0.8;

        private double openTranslationX => pageContainer.Width / 1.5d;
        private bool isMenuClosed = true;
        private BackgroundDrawable drawable;


        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(PageEnum.ProductDetailPage.ToString(), typeof(ProductDetailPage));

            backgroundGraphicsView.Drawable = drawable = new BackgroundDrawable
            {
                BackgroundColor = App.Current.Resources.GetValue<Color>("BackgroundColor"),
                DarkBackgroundColor = App.Current.Resources.GetValue<Color>("DarkBackgroundColor"),
                LightBackgroundColor = App.Current.Resources.GetValue<Color>("LightBackgroundColor"),
            };
            pageContainer.SizeChanged += PageContainerSizeChanged;

            Loaded += AppShellLoaded;
            Navigated += AppShellNavigated;
        }

        private void AppShellNavigated(object sender, ShellNavigatedEventArgs e)
        {
            CurrentPage.SetNavigationBarAppearence();
        }

        private void AppShellLoaded(object sender, EventArgs e)
        {
            Window.SubscribeToSafeAreaChanges(safeArea =>
            {
                appBar.Margin = safeArea;
                menuGrid.Margin = safeArea;
            });
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            pageOverlay.InputTransparent = true;
        }

        private void OpenMenu()
        {
            isMenuClosed = false;

            pageContainer.AbortAnimation(OpenMenuAnimationKey);
            pageContainer.AbortAnimation(CloseMenuAnimationKey);

            pageOverlay.InputTransparent = false;
            pageContainer.Clip = new RoundRectangleGeometry(new CornerRadius(30), new Rect(0, 0, pageContainer.Width, pageContainer.Height));
            
            Animation animation = new Animation(d =>
            {
                pageContainer.Scale = 1 - ((1 - OpenScale) * d);
                pageContainer.TranslationX = openTranslationX * d;
            });

            animation.Commit(pageContainer, OpenMenuAnimationKey, finished: (d, b) =>
            {
                pageContainer.Scale = OpenScale;
                pageContainer.TranslationX = openTranslationX;
            });

#if ANDROID
            this.Window.SetStatusBarAppearance(Colors.Transparent, true);
#endif
        }

        private void CloseMenu()
        {
            isMenuClosed = true;

            pageContainer.AbortAnimation(OpenMenuAnimationKey);
            pageContainer.AbortAnimation(CloseMenuAnimationKey);

            Animation animation = new Animation(d =>
            {
                pageContainer.Scale = OpenScale + ((1 - OpenScale) * d);
                pageContainer.TranslationX = openTranslationX - (openTranslationX * d);
            });

            animation.Commit(pageContainer, CloseMenuAnimationKey, finished: (d, b) =>
            {
                pageContainer.Scale = 1;
                pageContainer.TranslationX = 0;
                pageOverlay.InputTransparent = true;

                pageContainer.Clip = null;
            });

            CurrentPage.SetNavigationBarAppearence();
        }

        private void AppBarMenuClicked(object sender, EventArgs e)
        {
            if (isMenuClosed)
                OpenMenu();
        }

        private void CloseMenuButtonClicked(object sender, EventArgs e)
        {
            if (!isMenuClosed)
                CloseMenu();
        }

        private void AppBarBackClicked(object sender, EventArgs e)
        {
            GoToAsync("..");
        }

        private void MenuItemButtonClicked(object sender, EventArgs e)
        {
            var view = sender as View;
            var shellItem = view.BindingContext as BaseShellItem;

            GoToAsync($"///{shellItem.Route}");
            CloseMenu();
        }

        private void PageContainerSizeChanged(object sender, EventArgs e)
        {
            if (!isMenuClosed)
                CloseMenu();
        }

        private class BackgroundDrawable : IDrawable
        {
            private float darkRectRelativeHeight = 0.45f;
            private float visibleWidth = 12f;
            private float verticalOffset = 30f;
            private float cornerRadius => (float)(30f * OpenScale);

            public Color BackgroundColor { get; set; }
            public Color DarkBackgroundColor { get; set; }
            public Color LightBackgroundColor { get; set; }

            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
                canvas.SaveState();

                canvas.SetFillPaint(new SolidPaint(BackgroundColor), dirtyRect);
                canvas.FillRectangle(dirtyRect);

                var left = (dirtyRect.Width * 1.5f) - (dirtyRect.Width * OpenScale) - visibleWidth;
                var top = ((dirtyRect.Height - (dirtyRect.Height * OpenScale)) / 2f) + verticalOffset;

                RectF lightRect = new Rect(left, top, dirtyRect.Width * OpenScale, (dirtyRect.Height * OpenScale) - (2 * verticalOffset));

                canvas.SetFillPaint(new SolidPaint(LightBackgroundColor), lightRect);
                canvas.FillRoundedRectangle(lightRect, cornerRadius);

                var darkRectHeight = darkRectRelativeHeight * lightRect.Height;

                RectF darkRect = new Rect(lightRect.X, lightRect.Y + lightRect.Height - darkRectHeight, lightRect.Width, darkRectHeight);

                canvas.SetFillPaint(new SolidPaint(DarkBackgroundColor), darkRect);
                canvas.FillRoundedRectangle(darkRect, cornerRadius);

                canvas.RestoreState();
            }
        }
    }
}