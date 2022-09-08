using System.Windows.Input;

namespace GadgetStoreApp.Core
{
    public class ProductDetailPageViewModel : BasePageViewModel, IProductDetailPageViewModel
    {
        ICartManager cartManager;

        Product product;

        public Product Product
        {
            get => product;
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
                OnPropertyChanged(nameof(Favorite));
            }
        }
        public bool Favorite
        {
            get => Product?.Favorite == true;
            set
            {
                Product.Favorite = value;
                OnPropertyChanged(nameof(Favorite));
            }
        }
        public int CartCount { get => cartManager.Count; }

        public ICommand AddToCartCommand { get; private set; }
        public ICommand FavoriteCommand { get; private set; }
        public ICommand GoToCartCommand { get; private set; }

        public ProductDetailPageViewModel(INavigationService navigationService, ICartManager cartManager) : base(navigationService)
        {
            this.cartManager = cartManager;

            AddToCartCommand = new RelayCommand(parameter =>
            {
                cartManager.AddToCart(parameter as Product);
                OnPropertyChanged(nameof(CartCount));
            });
            FavoriteCommand = new RelayCommand(() => Favorite = !Favorite);
            GoToCartCommand = new RelayCommand(() => navigationService.Push(PageEnum.CartPage));
        }

        public override void OnPagePushing(params object[] parameters)
        {
            if (parameters is not null && parameters.Length != 0)
                Product = parameters[0] as Product;
        }
    }
}
