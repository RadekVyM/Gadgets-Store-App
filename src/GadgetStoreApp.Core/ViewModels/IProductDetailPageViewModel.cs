using System.Windows.Input;

namespace GadgetStoreApp.Core
{
    public interface IProductDetailPageViewModel
    {
        ICommand AddToCartCommand { get; }
        ICommand GoBackCommand { get; }
        Product Product { get; set; }
        bool Favorite { get; set; }
        int CartCount { get; }
        ICommand FavoriteCommand { get; }
        ICommand GoToCartCommand { get; }

        void OnPagePushing(params object[] parameters);
    }
}