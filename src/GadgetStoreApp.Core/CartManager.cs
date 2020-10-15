using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GadgetStoreApp.Core
{
    public class CartManager : ICartManager
    {
        public IReadOnlyCollection<Product> ProductsInCart { get; }
        public int Count => ProductsInCart.Count;

        public CartManager()
        {
            ProductsInCart = new ObservableCollection<Product>();
        }

        public void AddToCart(Product item) => ((ObservableCollection<Product>)ProductsInCart).Add(item);
    }
}
