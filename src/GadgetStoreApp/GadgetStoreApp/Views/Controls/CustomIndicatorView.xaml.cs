using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GadgetStoreApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomIndicatorView : ContentView
    {
        #region Private members

        double selectedWidth => 2 * defaultWidth;
        double defaultWidth => 12;
        double spacing => 5;
        double margin;
        double selectedOpacity => 1d;
        double defaultOpacity => 0.2d;
        List<double> positionsOnLeft;
        List<double> positionsOnRight;
        int selectedIndex = 0;

        #endregion

        public int Count
        {
            get => (int)GetValue(CountProperty);
            set => SetValue(CountProperty, value);
        }

        public static readonly BindableProperty CountProperty =
            BindableProperty.Create(nameof(Count), typeof(int), typeof(CustomIndicatorView), 0, BindingMode.OneWay, propertyChanged: MyPropertyChanged);

        private static void MyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomIndicatorView view = bindable as CustomIndicatorView;

            view.CustomIndicatorViewSizeChanged(view, null);
        }

        public CustomIndicatorView()
        {
            InitializeComponent();

            positionsOnLeft = new List<double>();
            positionsOnRight = new List<double>();

            SizeChanged += CustomIndicatorViewSizeChanged;
        }

        private void CustomIndicatorViewSizeChanged(object sender, EventArgs e)
        {
            grid.Children.Clear();

            for (int i = 0; i < Count; i++)
                grid.Children.Add(new BoxView
                {
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start,
                    IsVisible = true,
                    BackgroundColor = App.Current.Resources.GetValue<Color>("CardBackgroundColor"),
                    CornerRadius = new CornerRadius(Height / 2d)
                }) ;

            margin = (Width - ((defaultWidth * (Count - 1)) + selectedWidth + ((Count - 1) * spacing))) / 2;

            positionsOnLeft.Clear();
            positionsOnRight.Clear();

            positionsOnLeft.Add(margin);
            positionsOnRight.Add(margin);

            for (int i = 0; i < Count; i++)
            {
                positionsOnLeft.Add(margin + ((i + 1) * defaultWidth) + ((i + 1) * spacing));
                positionsOnRight.Add(margin + (selectedWidth + (i * defaultWidth)) + ((i + 1) * spacing));
            }

            foreach (var view in grid.Children)
            {
                int index = grid.Children.IndexOf(view);

                bool left = selectedIndex >= index;

                double x = left ? positionsOnLeft[index] : positionsOnRight[index];
                double y = 0;
                double width = index == selectedIndex ? selectedWidth : defaultWidth;
                double height = Height;

                view.Layout(new Rectangle(x, y, width, height));

                view.Opacity = index == selectedIndex ? selectedOpacity : defaultOpacity;
            }
        }

        public async void MoveTo(int newIndex)
        {
            int oldViewIndex = selectedIndex;

            if (oldViewIndex == newIndex)
                return;

            selectedIndex = newIndex;

            List<Task> tasks = new List<Task>();

            foreach (var view in grid.Children)
            {
                int index = grid.Children.IndexOf(view);

                bool left = newIndex >= index;
                
                if (index != newIndex)
                    tasks.Add(view.LayoutTo(new Rectangle(left ? positionsOnLeft[index] : positionsOnRight[index], view.Y, defaultWidth, view.Height)));
                else
                    tasks.Add(grid.Children[newIndex].LayoutTo(new Rectangle(positionsOnLeft[newIndex], grid.Children[newIndex].Y, selectedWidth, grid.Children[newIndex].Height)));

                tasks.Add(view.FadeTo(index == selectedIndex ? selectedOpacity : defaultOpacity));
            }

            await Task.WhenAll(tasks);
        }
    }
}