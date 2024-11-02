using System.Windows.Input;

namespace GadgetStoreApp.Core;

public interface IHomePageViewModel
{
    IList<Product> AllProducts { get; }
    IList<Product> PopularProducts { get; }
    ICommand ProductSelectedCommand { get; }
}