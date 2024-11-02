using GadgetStoreApp.Maui.Converters;
using GadgetStoreApp.Maui.Extensions;
using Microsoft.Maui.Controls.Shapes;

namespace GadgetStoreApp.Maui.Views.Controls;

public class RatingControl : GraphicsView
{
    private const string StarStringPath = "m 176.43154,78.307788 c 10.17093,0 20.52073,35.970222 28.74919,41.948552 8.22846,5.97832 45.63644,4.70616 48.77943,14.3793 3.14299,9.67313 -27.86846,30.63179 -31.01145,40.30492 -3.14299,9.67313 9.62661,44.85712 1.39815,50.83545 -8.22846,5.97832 -37.74439,-17.03874 -47.91533,-17.03874 -10.17093,0 -39.68687,23.01706 -47.91533,17.03873 -8.22845,-5.97832 4.54115,-41.16231 1.39815,-50.83544 -3.14299,-9.67313 -34.154436,-30.6318 -31.011445,-40.30493 3.142995,-9.67313 40.550975,-8.40097 48.779435,-14.37929 8.22845,-5.97833 18.57826,-41.948552 28.7492,-41.948552 z";
    private const int NumberOfStars = 5;

    private readonly PathGeometry starGeometry;
    private RatingDrawable drawable;

    public static readonly BindableProperty StarColorProperty =
        BindableProperty.Create(nameof(StarColor), typeof(Color), typeof(RatingControl), Colors.Black, BindingMode.OneWay, propertyChanged: MyPropertyChanged);

    public static readonly BindableProperty DefaultColorProperty =
        BindableProperty.Create(nameof(DefaultColor), typeof(Color), typeof(RatingControl), Colors.Black, BindingMode.OneWay, propertyChanged: MyPropertyChanged);

    public static readonly BindableProperty RatingProperty =
        BindableProperty.Create(nameof(Rating), typeof(double), typeof(RatingControl), 0d, BindingMode.OneWay, propertyChanged: MyPropertyChanged);

    public double Rating
    {
        get => (double)GetValue(RatingProperty);
        set => SetValue(RatingProperty, value);
    }

    public Color StarColor
    {
        get => (Color)GetValue(StarColorProperty);
        set => SetValue(StarColorProperty, value);
    }

    public Color DefaultColor
    {
        get => (Color)GetValue(DefaultColorProperty);
        set => SetValue(DefaultColorProperty, value);
    }


    public RatingControl()
    {
        starGeometry = new PathGeometryConverter().ConvertFromInvariantString(StarStringPath) as PathGeometry;
        Drawable = drawable = new RatingDrawable
        {
            StarGeometry = starGeometry
        };

        InputTransparent = true;
    }


    private static void MyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = bindable as RatingControl;

        view.drawable.Rating = view.Rating;
        view.drawable.StarColor = view.StarColor;
        view.drawable.DefaultColor = view.DefaultColor;

        view.Invalidate();
    }


    private class RatingDrawable : IDrawable
    {
        private const float spacing = 2;

        private float spacingSum => (spacing * (NumberOfStars - 1));

        public double Rating { get; set; }
        public Color StarColor { get; set; }
        public Color DefaultColor { get; set; }
        public PathGeometry StarGeometry { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.SaveState();

            var starPath = StarGeometry.ParseToPathF();
            var size = Math.Min(dirtyRect.Height, (dirtyRect.Width - spacingSum) / NumberOfStars);

            starPath = starPath.AsUniformScaledPath(new RectF(0, 0, size, size));
            starPath.Move((dirtyRect.Width - (size * NumberOfStars) - spacingSum) / 2, 0);

            var paint = new LinearGradientPaint(new PaintGradientStop[]
            {
                new PaintGradientStop((float)(Rating / NumberOfStars), StarColor),
                new PaintGradientStop((float)(Rating / NumberOfStars), DefaultColor),
                new PaintGradientStop(1, DefaultColor),
            }, new Point(0, 0), new Point(1,0));

            var paintBounds = new Rect(starPath.Bounds.X, 0, spacingSum + (size * NumberOfStars), dirtyRect.Height);

            canvas.SetFillPaint(paint, paintBounds);

            for (int i = 0; i < NumberOfStars; i++)
            {
                canvas.FillPath(starPath);
                starPath.Move(size + spacing, 0);

#if IOS || MACCATALYST
                canvas.SetFillPaint(paint, paintBounds);
#endif
            }

            canvas.RestoreState();
        }
    }
}