using GadgetStoreApp.Core;

namespace GadgetStoreApp.Maui.Services;

public class NavigationService : INavigationService
{
    private readonly PageEnum[] rootPages = [PageEnum.HomePage, PageEnum.ProfilePage, PageEnum.SettingsPage, PageEnum.BalancePage, PageEnum.CartPage, PageEnum.FavoritesPage, PageEnum.HelpPage];

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
            return $"///{page}";
        return page.ToString();
    }
}