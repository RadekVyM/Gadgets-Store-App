using System.Collections.ObjectModel;

namespace GadgetStoreApp.Core;

public class CartManager : ICartManager
{
    private readonly ObservableCollection<Product> productsInCart = [];

    public IReadOnlyCollection<Product> ProductsInCart => productsInCart;
    public int Count => ProductsInCart.Count;

    public void AddToCart(Product item) => productsInCart.Add(item);
}