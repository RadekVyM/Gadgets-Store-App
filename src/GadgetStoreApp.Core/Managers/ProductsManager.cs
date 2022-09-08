using System.Collections.Generic;
using System.Linq;

namespace GadgetStoreApp.Core
{
    public class ProductsManager : IProductsManager
    {
        public IEnumerable<Product> GetPopularProducts()
        {
            var list = new List<Product>()
            {
                new Product
                {
                    Name = "Sony WH",
                    CurrentPrice = 250,
                    PreviousPrice = 500,
                    ShortDescription = "3D Sound 2.5Hz",
                    LongDescription = "Sony Technical features is including a masterclass.",
                    Rating = 4.5d,
                    ThumbnailImageIndex = 0,
                    Images = new List<string>()
                    {
                        "sony1.jpg",
                        "sony2.jpg",
                        "sony3.jpg"
                    },
                    Features = new List<Feature>()
                    {
                        new Feature{ FeatureEnum = FeatureEnum.BatteryEndurance, Value = "36h" },
                        new Feature{ FeatureEnum = FeatureEnum.UnderwaterEndurance, Value = "32m" },
                        new Feature{ FeatureEnum = FeatureEnum.Bluetooth, Value = 3.9d.ToString("0.0") },
                        new Feature{ FeatureEnum = FeatureEnum.RandomSpec, Value = "2d" }
                    }
                },
                new Product
                {
                    Name = "Freebuds 2",
                    CurrentPrice = 125,
                    PreviousPrice = 250,
                    ShortDescription = "3D Sound 2.4Hz",
                    LongDescription = "Huawei Technical features is including a masterclass.",
                    Rating = 4.9d,
                    ThumbnailImageIndex = 0,
                    Images = new List<string>()
                    {
                        "freebuds1.jpg",
                        "freebuds2.jpg",
                        "freebuds3.jpg"
                    },
                    Features = new List<Feature>()
                    {
                        new Feature{ FeatureEnum = FeatureEnum.BatteryEndurance, Value = "6h" },
                        new Feature{ FeatureEnum = FeatureEnum.UnderwaterEndurance, Value = "10m" },
                        new Feature{ FeatureEnum = FeatureEnum.Bluetooth, Value = 3.9d.ToString("0.0") },
                        new Feature{ FeatureEnum = FeatureEnum.RandomSpec, Value = "1d" }
                    }
                },
                new Product
                {
                    Name = "Apple Watch",
                    CurrentPrice = 200,
                    PreviousPrice = 400,
                    ShortDescription = "Nike Edition",
                    LongDescription = "Apple Technical features is including a masterclass.",
                    Rating = 5,
                    ThumbnailImageIndex = 1,
                    Images = new List<string>()
                    {
                        "apple1.jpg",
                        "apple2.jpg",
                        "apple3.jpg"
                    },
                    Features = new List<Feature>()
                    {
                        new Feature{ FeatureEnum = FeatureEnum.BatteryEndurance, Value = "25h" },
                        new Feature{ FeatureEnum = FeatureEnum.UnderwaterEndurance, Value = "20m" },
                        new Feature{ FeatureEnum = FeatureEnum.Bluetooth, Value = 3.9d.ToString("0.0") },
                        new Feature{ FeatureEnum = FeatureEnum.RandomSpec, Value = "3d" }
                    }
                }
            };

            return list;
        }

        public IEnumerable<Product> GetBestSellingProducts()
        {
            var list = new List<Product>()
            {
                new Product
                {
                    Name = "Erupt M9",
                    CurrentPrice = 399,
                    PreviousPrice = 399,
                    ShortDescription = "3D Sound 2.5Hz",
                    LongDescription = "M9 Technical features is including a masterclass.",
                    Rating = 5,
                    ThumbnailImageIndex = 2,
                    Images = new List<string>()
                    {
                        "vokyl1.jpg",
                        "vokyl2.jpg",
                        "vokyl3.jpg"
                    },
                    Features = new List<Feature>()
                    {
                        new Feature{ FeatureEnum = FeatureEnum.BatteryEndurance, Value = "24h" },
                        new Feature{ FeatureEnum = FeatureEnum.UnderwaterEndurance, Value = "30m" },
                        new Feature{ FeatureEnum = FeatureEnum.Bluetooth, Value = 3.9d.ToString("0.0") },
                        new Feature{ FeatureEnum = FeatureEnum.RandomSpec, Value = "3d" }
                    }
                },
                new Product
                {
                    Name = "Nura M9",
                    CurrentPrice = 344,
                    PreviousPrice = 429,
                    ShortDescription = "ANC, Immersion",
                    LongDescription = "M9 Technical features is including a masterclass.",
                    Rating = 4.8d,
                    ThumbnailImageIndex = 2,
                    Images = new List<string>()
                    {
                        "nura1.jpg",
                        "nura2.jpg",
                        "nura3.jpg"
                    },
                    Features = new List<Feature>()
                    {
                        new Feature{ FeatureEnum = FeatureEnum.BatteryEndurance, Value = "24h" },
                        new Feature{ FeatureEnum = FeatureEnum.UnderwaterEndurance, Value = "30m" },
                        new Feature{ FeatureEnum = FeatureEnum.Bluetooth, Value = 3.9d.ToString("0.0") },
                        new Feature{ FeatureEnum = FeatureEnum.RandomSpec, Value = "3d" }
                    }
                },
                new Product
                {
                    Name = "Sony WH",
                    CurrentPrice = 250,
                    PreviousPrice = 500,
                    ShortDescription = "3D Sound 2.5Hz",
                    LongDescription = "Sony Technical features is including a masterclass.",
                    Rating = 3.4d,
                    ThumbnailImageIndex = 2,
                    Images = new List<string>()
                    {
                        "sony1.jpg",
                        "sony2.jpg",
                        "sony3.jpg"
                    },
                    Features = new List<Feature>()
                    {
                        new Feature{ FeatureEnum = FeatureEnum.BatteryEndurance, Value = "36h" },
                        new Feature{ FeatureEnum = FeatureEnum.UnderwaterEndurance, Value = "32m" },
                        new Feature{ FeatureEnum = FeatureEnum.Bluetooth, Value = 3.9d.ToString("0.0") },
                        new Feature{ FeatureEnum = FeatureEnum.RandomSpec, Value = "2d" }
                    }
                }
            };

            return list;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return GetPopularProducts().Concat(GetBestSellingProducts().Concat(GetPopularProducts().Concat(GetBestSellingProducts())));
        }
    }
}
