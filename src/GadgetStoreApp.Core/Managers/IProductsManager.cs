using System.Collections.Generic;

namespace GadgetStoreApp.Core
{
    public interface IProductsManager
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetPopularProducts();
        IEnumerable<Product> GetLimitedOfferProducts();
    }
}