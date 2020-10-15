using System.Windows.Input;

namespace GadgetStoreApp.Core
{
    public interface IProductDetailPageViewModel
    {
        ICommand AddToCartCommand { get; }
        ICommand GoBackCommand { get; }
        Product Product { get; set; }

        void OnPagePushing(params object[] parameters);
    }
}