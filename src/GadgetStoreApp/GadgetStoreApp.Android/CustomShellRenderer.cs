using Android.Content;
using GadgetStoreApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace GadgetStoreApp.Droid
{
    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer(Context context) : base(context)
        {
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            return new CustomShellItemRenderer(this);
        }

        protected override IShellFlyoutRenderer CreateShellFlyoutRenderer()
        {
            return new CustomShellFlyoutRenderer(this, AndroidContext);
        }
    }
}