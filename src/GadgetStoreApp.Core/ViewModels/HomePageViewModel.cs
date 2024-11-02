using System.Windows.Input;

namespace GadgetStoreApp.Core;

public class HomePageViewModel(INavigationService navigationService, IProductsManager productsManager) : BasePageViewModel(navigationService), IHomePageViewModel
{
    public IList<Product> PopularProducts { get; } = productsManager.GetPopularProducts().ToList();
    public IList<Product> AllProducts { get; } = productsManager.GetAllProducts().ToList();

    public ICommand ProductSelectedCommand { get; } = new RelayCommand(parameter => navigationService.Push(PageEnum.ProductDetailPage, parameter));
}