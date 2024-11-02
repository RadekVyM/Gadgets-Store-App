using GadgetStoreApp.Maui.Extensions;

namespace GadgetStoreApp.Maui.Views.Controls
{
    public class CustomIndicatorView : GraphicsView
    {
        private const string AnimationKey = "Animation";

        private readonly IndicatorDrawable drawable;

        public static readonly BindableProperty CountProperty =
            BindableProperty.Create(nameof(Count), typeof(int), typeof(CustomIndicatorView), 0, BindingMode.OneWay, propertyChanged: OnCountPropertyChanged);
       
        public int Count
        {
            get => (int)GetValue(CountProperty);
            set => SetValue(CountProperty, value);
        }


        public CustomIndicatorView()
        {
            var color = App.Current.Resources.GetValue<Color>("Secondary");
            
            Drawable = drawable = new IndicatorDrawable
            {
                Color = color
            };
        }


        public void MoveTo(int newIndex)
        {
            if (drawable.SelectedIndex == newIndex)
                return;

            this.AbortAnimation(AnimationKey);

            uint animationLength = 250;

            drawable.OldSelectedIndex = drawable.SelectedIndex;
            drawable.SelectedIndex = newIndex;

            var animation = new Animation(v =>
            {
                drawable.AnimationProgress = v;
                Invalidate();
            });

            animation.Commit(this, AnimationKey, length: animationLength, finished: (d, b) =>
            {
                drawable.AnimationProgress = 1;
                Invalidate();
            });
        }

        private static void OnCountPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as CustomIndicatorView;
            view.drawable.Count = (int)newValue;
            view.Invalidate();
        }

        private class IndicatorDrawable : IDrawable
        {
            private float selectedWidth => 2f * defaultWidth;
            private float defaultWidth => 12f;
            private float spacing => 5f;
            private float selectedOpacity => 1f;
            private float defaultOpacity => 0.4f;

            public Color Color { get; set; }
            public int Count { get; set; }
            public int SelectedIndex { get; set; } = 0;
            public int OldSelectedIndex { get; set; } = 0;
            public double AnimationProgress { get; set; } = 1;


            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
                canvas.SaveState();

                float left = (dirtyRect.Width - ((defaultWidth * (Count - 1)) + selectedWidth + ((Count - 1) * spacing))) / 2;

                for (int i = 0; i < Count; i++)
                {
                    float width;
                    float opacity;

                    if (i == SelectedIndex)
                    {
                        width = defaultWidth + ((selectedWidth - defaultWidth) * (float)AnimationProgress);
                        opacity = defaultOpacity + ((selectedOpacity - defaultOpacity) * (float)AnimationProgress);
                    }
                    else if (i == OldSelectedIndex)
                    {
                        width = selectedWidth - ((selectedWidth - defaultWidth) * (float)AnimationProgress);
                        opacity = selectedOpacity - ((selectedOpacity - defaultOpacity) * (float)AnimationProgress);
                    }
                    else
                    {
                        width = defaultWidth;
                        opacity = defaultOpacity;
                    }

                    var color = Color.FromRgba(Color.Red, Color.Green, Color.Blue, opacity);
                    var rect = new RectF(left, 0, width, dirtyRect.Height);

                    canvas.SetFillPaint(new SolidPaint(color), rect);

                    canvas.FillRoundedRectangle(rect, dirtyRect.Height / 2);

                    left += width + spacing;
                }

                canvas.RestoreState();
            }
        }
    }
}
