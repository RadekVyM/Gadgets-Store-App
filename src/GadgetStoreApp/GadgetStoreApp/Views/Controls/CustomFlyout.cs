using System.Threading.Tasks;
using Xamarin.Forms;

namespace GadgetStoreApp
{
    public class CustomFlyout : FlyoutItem
    {
        public ReversedFlyout ReversedFlyout { get; set; }

        public CustomFlyout()
        {
            ReversedFlyout = new ReversedFlyout();
        }
    }
}
