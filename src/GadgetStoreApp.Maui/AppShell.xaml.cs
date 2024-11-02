using GadgetStoreApp.Core;
using GadgetStoreApp.Maui.Views.Pages;
using Microsoft.Maui.Controls.Shapes;
using SimpleToolkit.Core;

namespace GadgetStoreApp.Maui;

public partial class AppShell : SimpleToolkit.SimpleShell.SimpleShell
{
    private const string OpenMenuAnimationKey = "OpenMenuAnimation";
    private const string CloseMenuAnimationKey = "CloseMenuAnimation";
    private const double OpenScale = 0.8;
    private const double PageCornerRadius = 20;

    private double openTranslationX => pageContainer.Width / 1.9d;
    private bool isMenuClosed = true;


    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(PageEnum.ProductDetailPage.ToString(), typeof(ProductDetailPage));

        pageContainer.SizeChanged += PageContainerSizeChanged;

        Loaded += AppShellLoaded;
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

        // TODO: On Android, change of the InputTransparent property value does not work
        pageOverlay.InputTransparent = false;
        pageContainer.Clip = new RoundRectangleGeometry(new CornerRadius(PageCornerRadius), new Rect(0, 0, pageContainer.Width, pageContainer.Height));
        
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
        menuGrid.HeightRequest = pageContainer.Height * OpenScale;

        if (!isMenuClosed)
            CloseMenu();
    }
}