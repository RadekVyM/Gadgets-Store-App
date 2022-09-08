using System.Collections.Generic;

namespace GadgetStoreApp.Core
{
    public interface IProductsManager
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetBestSellingProducts();
        IEnumerable<Product> GetPopularProducts();
    }
}