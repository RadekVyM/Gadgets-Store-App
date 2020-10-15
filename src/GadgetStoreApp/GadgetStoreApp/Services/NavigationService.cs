using GadgetStoreApp.Core;
using System.Linq;
using Xamarin.Forms;

namespace GadgetStoreApp
{
    public class NavigationService : INavigationService
    {
        public async void OpenFlyout()
        {
            if (Shell.Current.CurrentItem is CustomFlyout flyout)
            {
                await flyout.ReversedFlyout.OpenAsync();
            }
        }

        public void Pop()
        {
            Shell.Current.Navigation.PopAsync();
        }

        public void Push(PageEnum page, params object[] parameters)
        {
            Shell.Current.GoToAsync(page.ToString());
            Page lastPage = Shell.Current.Navigation.NavigationStack.LastOrDefault();

            if (lastPage != null)
                ((IBasePageViewModel)lastPage.BindingContext).OnPagePushing(parameters);
        }
    }
}
