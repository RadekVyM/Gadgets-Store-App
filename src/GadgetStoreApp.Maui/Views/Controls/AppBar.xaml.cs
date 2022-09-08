namespace GadgetStoreApp.Maui.Views.Controls
{
    public partial class AppBar : ContentView
    {
        private readonly Color lightColor = Colors.White;
        private readonly Color darkColor = Colors.Black;

        public event EventHandler BackClicked { add => backButton.Clicked += value; remove => backButton.Clicked -= value; }
        public event EventHandler MenuClicked { add => menuButton.Clicked += value; remove => menuButton.Clicked -= value; }
        public event EventHandler SearchClicked { add => searchButton.Clicked += value; remove => searchButton.Clicked -= value; }

        public static Thickness AppBarPadding => new Thickness(0, 80, 0, 0);

        public static readonly BindableProperty StateProperty = BindableProperty.Create(nameof(State), typeof(AppBarState), typeof(AppBar), propertyChanged: OnStateChanged);
        public static readonly BindableProperty BackgroundTypeProperty = BindableProperty.Create(nameof(BackgroundType), typeof(BackgroundType), typeof(AppBar), propertyChanged: OnBackgroundTypeChanged);

        public virtual AppBarState State
        {
            get => (AppBarState)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }

        public virtual BackgroundType BackgroundType
        {
            get => (BackgroundType)GetValue(BackgroundTypeProperty);
            set => SetValue(BackgroundTypeProperty, value);
        }


        public AppBar()
        {
            InitializeComponent();

            UpdateStateOfControls(State);
            UpdateColorOfControls(BackgroundType);
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

        private void UpdateColorOfControls(BackgroundType backgroundType)
        {
            switch (backgroundType)
            {
                case BackgroundType.Light:
                    menuIcon.TintColor = darkColor;
                    backIcon.TintColor = darkColor;
                    searchIcon.TintColor = darkColor;
                    break;
                case BackgroundType.Dark:
                    menuIcon.TintColor = lightColor;
                    backIcon.TintColor = lightColor;
                    searchIcon.TintColor = lightColor;
                    break;
            }
        }

        private static void OnStateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var appBar = bindable as AppBar;
            var newState = (AppBarState)newValue;

            appBar.UpdateStateOfControls(newState);
        }

        private static void OnBackgroundTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var appBar = bindable as AppBar;
            var backgroundType = (BackgroundType)newValue;

            appBar.UpdateColorOfControls(backgroundType);
        }
    }

    public enum AppBarState
    {
        Root, Back
    }

    public enum BackgroundType
    {
        Light, Dark
    }
}
