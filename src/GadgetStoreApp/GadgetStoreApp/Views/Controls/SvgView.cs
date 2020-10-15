using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace GadgetStoreApp
{
    public class SvgView : SKCanvasView
    {
        #region Public members

        public object Colour
        {
            get => GetValue(ColourProperty);
            set => SetValue(ColourProperty, value);
        }

        public string Path
        {
            get => (string)GetValue(PathProperty);
            set => SetValue(PathProperty, value);
        }

        public static readonly BindableProperty ColourProperty =
            BindableProperty.Create(nameof(Colour), typeof(object), typeof(SvgView), Color.Black, BindingMode.OneWay, propertyChanged: MyPropertyChanged);

        public static readonly BindableProperty PathProperty =
            BindableProperty.Create(nameof(Path), typeof(string), typeof(SvgView), "", BindingMode.OneWay, propertyChanged: MyPropertyChanged);

        private static void MyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SvgView svgView = bindable as SvgView;

            try
            {
                svgView.InvalidateSurface();
            }
            catch { };
        }

        #endregion


        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var info = e.Info;
            canvas.Clear();

            if (string.IsNullOrWhiteSpace(Path))
                return;

            SKPath path = SKPath.ParseSvgPathData(Path);

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Fill;
                paint.Color = Colour.GetColour().ToSKColor();
                paint.StrokeCap = SKStrokeCap.Round;
                paint.StrokeJoin = SKStrokeJoin.Round;
                paint.IsAntialias = true;

                path.GetBounds(out SKRect bounds);

                canvas.Translate(info.Width / 2, info.Height / 2);
                canvas.Scale(Math.Min(info.Width / bounds.Width, info.Height / bounds.Height));
                canvas.Translate(-bounds.MidX, -bounds.MidY);

                canvas.DrawPath(path, paint);
            };
        }
    }
}
