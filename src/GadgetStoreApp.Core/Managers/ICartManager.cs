using System.Collections.Generic;

namespace GadgetStoreApp.Core
{
    public interface ICartManager
    {
        int Count { get; }
        IReadOnlyCollection<Product> ProductsInCart { get; }
        void AddToCart(Product item);
    }
}