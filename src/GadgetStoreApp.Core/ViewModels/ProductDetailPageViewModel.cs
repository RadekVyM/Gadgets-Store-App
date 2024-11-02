using System.Windows.Input;

namespace GadgetStoreApp.Core;

public class ProductDetailPageViewModel : BasePageViewModel, IProductDetailPageViewModel
{
    private readonly ICartManager cartManager;

    private Product product = null!;

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
    public int CartCount => cartManager.Count;

    public ICommand AddToCartCommand { get; private init; }
    public ICommand FavoriteCommand { get; private init; }
    public ICommand GoToCartCommand { get; private init; }


    public ProductDetailPageViewModel(INavigationService navigationService, ICartManager cartManager) : base(navigationService)
    {
        this.cartManager = cartManager;

        AddToCartCommand = new RelayCommand(parameter =>
        {
            if (parameter is Product product)
                cartManager.AddToCart(product);
            OnPropertyChanged(nameof(CartCount));
        });
        FavoriteCommand = new RelayCommand(() => Favorite = !Favorite);
        GoToCartCommand = new RelayCommand(() => navigationService.Push(PageEnum.CartPage));
    }


    public override void OnPagePushing(params object[] parameters)
    {
        if (parameters is not null && parameters.Length != 0 && parameters[0] is Product product)
            Product = product;
    }
}