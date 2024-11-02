namespace GadgetStoreApp.Maui.Views.Controls;

public partial class AppBar : ContentView
{
    public event EventHandler BackClicked { add => backButton.Clicked += value; remove => backButton.Clicked -= value; }
    public event EventHandler MenuClicked { add => menuButton.Clicked += value; remove => menuButton.Clicked -= value; }
    public event EventHandler ShoppingBagClicked { add => shoppingBagButton.Clicked += value; remove => shoppingBagButton.Clicked -= value; }

    public static Thickness AppBarPadding => new(0, 80, 0, 0);

    public static readonly BindableProperty StateProperty = BindableProperty.Create(nameof(State), typeof(AppBarState), typeof(AppBar), propertyChanged: OnStateChanged);

    public virtual AppBarState State
    {
        get => (AppBarState)GetValue(StateProperty);
        set => SetValue(StateProperty, value);
    }


    public AppBar()
    {
        InitializeComponent();

        UpdateStateOfControls(State);
    }


    private void UpdateStateOfControls(AppBarState state)
    {
        switch (state)
        {
            case AppBarState.Root:
                menuButton.IsVisible = true;
                backButton.IsVisible = false;
                break;
            case AppBarState.Back:
                menuButton.IsVisible = false;
                backButton.IsVisible = true;
                break;
        }
    }

    private static void OnStateChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var appBar = bindable as AppBar;
        var newState = (AppBarState)newValue;

        appBar.UpdateStateOfControls(newState);
    }
}

public enum AppBarState
{
    Root, Back
}