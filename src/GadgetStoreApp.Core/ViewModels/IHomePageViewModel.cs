using System.Collections.Generic;
using System.Windows.Input;

namespace GadgetStoreApp.Core
{
    public interface IHomePageViewModel
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> BestSellingProducts { get; }
        ICommand OpenFlyoutCommand { get; }
        IEnumerable<Product> PopularProducts { get; }
        ICommand ProductSelectedCommand { get; }
    }
}