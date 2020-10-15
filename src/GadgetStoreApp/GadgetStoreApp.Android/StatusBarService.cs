using Android.Views;
using Xamarin.Forms;

[assembly: Dependency(typeof(GadgetStoreApp.Droid.StatusBarService))]
namespace GadgetStoreApp.Droid
{
    public class StatusBarService : GadgetStoreApp.IStatusBarService
    {
        public int GetHeight()
        {
            int statusBarHeight = -1;
            int resourceId = MainActivity.Current.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                statusBarHeight = MainActivity.Current.Resources.GetDimensionPixelSize(resourceId);
            }
            return statusBarHeight;
        }

        public void SetLightStatusBar(bool light)
        {
            int uiOptions = (int)MainActivity.Current.Window.DecorView.SystemUiVisibility;

            if (light)
                uiOptions |= (int)SystemUiFlags.LightStatusBar;
            else
                uiOptions &= ~(int)SystemUiFlags.LightStatusBar;

            MainActivity.Current.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }
    }
}