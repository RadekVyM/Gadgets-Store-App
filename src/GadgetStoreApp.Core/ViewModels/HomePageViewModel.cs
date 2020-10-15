using System.Collections.Generic;
using System.Windows.Input;

namespace GadgetStoreApp.Core
{
    public class HomePageViewModel : BasePageViewModel, IHomePageViewModel
    {
        public IEnumerable<Product> PopularProducts { get; private set; }
        public IEnumerable<Product> BestSellingProducts { get; private set; }
        public IEnumerable<Product> AllProducts { get; private set; }

        public ICommand ProductSelectedCommand { get; private set; }
        public ICommand OpenFlyoutCommand { get; private set; }

        public HomePageViewModel(INavigationService navigationService, IProductsManager productsManager) : base(navigationService)
        {
            PopularProducts = productsManager.GetPopularProducts();
            BestSellingProducts = productsManager.GetBestSellingProducts();
            AllProducts = productsManager.GetAllProducts();

            ProductSelectedCommand = new RelayCommand(parameter => { navigationService.Push(PageEnum.ProductDetailPage, parameter); });
            OpenFlyoutCommand = new RelayCommand(() => navigationService.OpenFlyout());
        }
    }
}
