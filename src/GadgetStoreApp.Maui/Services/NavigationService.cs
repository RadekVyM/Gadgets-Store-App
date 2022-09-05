using GadgetStoreApp.Core;

namespace GadgetStoreApp.Maui.Services
{
    public class NavigationService : INavigationService
    {
        private PageEnum[] rootPages = new PageEnum[] { PageEnum.HomePage, PageEnum.ProfilePage, PageEnum.SettingsPage, PageEnum.BalancePage, PageEnum.CartPage, PageEnum.FavoritesPage, PageEnum.HelpPage };

        public async void OpenFlyout()
        {
            //    if (Shell.Current.CurrentItem is CustomFlyout flyout)
            //    {
            //        await flyout.ReversedFlyout.OpenAsync();
            //    }
        }

        public void Pop()
        {
            Shell.Current.Navigation.PopAsync();
        }

        public void Push(PageEnum page, params object[] parameters)
        {
            Shell.Current.GoToAsync(GetPagePath(page));
            Page lastPage = Shell.Current.Navigation.NavigationStack.LastOrDefault();

            if (lastPage != null)
                ((IBasePageViewModel)lastPage.BindingContext).OnPagePushing(parameters);
        }

        private string GetPagePath(PageEnum page)
        {
            if (rootPages.Contains(page))
                return $"///{page.ToString()}";
            return page.ToString();
        }
    }
}
