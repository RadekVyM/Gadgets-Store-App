using Android.Graphics;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(GadgetStoreApp.Droid.ScreenshotService))]
namespace GadgetStoreApp.Droid
{
    public class ScreenshotService : IScreenshotService
    {
        // Based on: https://www.xamarinhelp.com/taking-a-screenshot-in-xamarin-forms/

        public byte[] MakeScreenShot()
        {
            var rootView = MainActivity.Current.Window.DecorView.RootView;

            using (var screenshot = Bitmap.CreateBitmap(rootView.Width, rootView.Height, Bitmap.Config.Argb8888))
            {
                var canvas = new Canvas(screenshot);
                rootView.Draw(canvas);

                using (var stream = new MemoryStream())
                {
                    // Bitmap.CompressFormat.Jpeg is much faster than Bitmap.CompressFormat.Png
                    screenshot.Compress(Bitmap.CompressFormat.Jpeg, 90, stream);
                    return stream.ToArray();
                }
            }
        }
    }
}