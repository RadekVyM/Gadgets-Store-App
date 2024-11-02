namespace GadgetStoreApp.Core;

public class ProductsManager : IProductsManager
{
    public IEnumerable<Product> GetLimitedOfferProducts() =>
    [
        new Product(
            Name: "Noctal Pro 12",
            CurrentPrice: 299,
            PreviousPrice: 399,
            ShortDescription: "Headphones for immersive listening",
            LongDescription : "Immerse yourself in a world of pure sound with our headphones. Experience crystal-clear audio, deep bass, and noise-canceling technology that blocks out distractions. Whether you're commuting, working out, or simply relaxing, our headphones provide the perfect auditory escape.",
            Rating: 4.7d,
            ThumbnailImageIndex: 0,
            Images:
            [
                "headphones03_1.jpg",
                "headphones03_2.jpg",
                "headphones03_3.jpg"
            ],
            Features:
            [
                new Feature(FeatureEnum.BatteryEndurance, "6h"),
                new Feature(FeatureEnum.UnderwaterEndurance, "2m"),
                new Feature(FeatureEnum.Bluetooth, "5.3"),
            ]
        ),
        new Product(
            Name: "SoundSurge Max",
            CurrentPrice : 344,
            PreviousPrice: 429,
            ShortDescription : "High-quality audio, wireless freedom",
            LongDescription: "The SoundSurge Max wireless headphones offer immersive audio experiences without the hassle of tangled wires. Equipped with advanced noise-cancellation technology, you can escape distractions and indulge in crystal-clear sound. The ergonomic design ensures a comfortable fit for extended listening sessions, while the intuitive touch controls allow for seamless music playback and call management. With long-lasting battery life and quick charging capabilities, you can stay connected to your music all day long.",
            Rating: 4d,
            ThumbnailImageIndex: 0,
            Images:
            [
                "headphones04_1.jpg",
                "headphones04_2.jpg",
            ],
            Features:
            [
                new Feature(FeatureEnum.BatteryEndurance, "12h"),
                new Feature(FeatureEnum.Bluetooth, "5.3"),
                new Feature(FeatureEnum.RandomSpec, "3D"),
            ]
        ),
        new Product(
            Name: "OrionWatch 4s",
            CurrentPrice: 199,
            PreviousPrice: 399,
            ShortDescription : "Your wrist, your world, connected",
            LongDescription: "The OrionWatch 4s smartwatch is your personal health and fitness companion. Its sleek design and vibrant display make it a stylish accessory, while its advanced features keep you connected and motivated. Track your heart rate, monitor your sleep patterns, and count your steps with ease. Receive notifications, control your music, and even make calls directly from your wrist. With its long-lasting battery and water-resistant design, the PulsePro is the perfect smartwatch for an active lifestyle.",
            Rating: 3.6,
            ThumbnailImageIndex: 0,
            Images:
            [
                "smartwatch02_1.jpg",
                "smartwatch02_2.jpg",
            ],
            Features:
            [
                new Feature(FeatureEnum.BatteryEndurance, "12h"),
                new Feature(FeatureEnum.UnderwaterEndurance, "1m"),
                new Feature(FeatureEnum.Bluetooth, "4.0"),
            ]
        ),
        new Product(
            Name: "ChronoZen 8",
            CurrentPrice: 99,
            PreviousPrice: 129,
            ShortDescription : "Effortless style, essential tech",
            LongDescription: "The ChronoZen 8 smartwatch is more than just a timepiece; it's your personal fitness and lifestyle assistant. Its sleek design and customizable watch faces complement any style, while its advanced features keep you connected and informed. Monitor your heart rate, track your workouts, and optimize your sleep with precision. Receive notifications, control your music, and make calls directly from your wrist. With its long-lasting battery and water-resistant design, the ChronoZen 8 is ready to accompany you on every adventure.",
            Rating: 4.1,
            ThumbnailImageIndex: 1,
            Images:
            [
                "smartwatch03_1.jpg",
                "smartwatch03_2.jpg",
            ],
            Features:
            [
                new Feature(FeatureEnum.BatteryEndurance, "14h"),
                new Feature(FeatureEnum.UnderwaterEndurance, "1m"),
                new Feature(FeatureEnum.Bluetooth, "4.3"),
            ]
        )
    ];

    public IEnumerable<Product> GetPopularProducts() =>
    [
        new Product(
            Name: "NovaWatch 2 Pro",
            CurrentPrice: 350,
            PreviousPrice: 390,
            ShortDescription: "Stay connected, stay active",
            LongDescription: "The NovaWatch 2 Pro is a cutting-edge smartwatch designed to seamlessly integrate into your modern lifestyle. With its vibrant touchscreen display, you can effortlessly monitor your fitness goals, receive notifications, and stay connected on the go. Packed with advanced features like heart rate tracking, sleep monitoring, and GPS, this smartwatch empowers you to optimize your health and performance. Its sleek design and customizable watch faces allow you to express your unique style while staying informed and motivated throughout your day.",
            Rating: 4.8,
            ThumbnailImageIndex: 0,
            Images:
            [
                "smartwatch01_1.jpg",
                "smartwatch01_2.jpg",
            ],
            Features:
            [
                new Feature(FeatureEnum.BatteryEndurance, "24h"),
                new Feature(FeatureEnum.UnderwaterEndurance, "30m"),
                new Feature(FeatureEnum.Bluetooth, "5.0"),
            ]
        ),
        new Product(
            Name: "Novabuds 4",
            CurrentPrice: 125,
            PreviousPrice: 250,
            ShortDescription: "True wireless freedom, compact sound",
            LongDescription: "The Novabuds 4 are compact and wireless earbuds that offer a premium listening experience. With active noise cancellation, you can immerse yourself in your music or calls without interruptions. The adaptive EQ automatically adjusts the sound to your ears, ensuring optimal audio quality. The intuitive touch controls allow for easy music playback and call management, while the comfortable and secure fit guarantees all-day wear.",
            Rating: 5d,
            ThumbnailImageIndex: 0,
            Images:
            [
                "headphones01_1.jpg",
                "headphones01_2.jpg",
                "headphones01_3.jpg",
            ],
            Features:
            [
                new Feature(FeatureEnum.BatteryEndurance, "4h"),
                new Feature(FeatureEnum.UnderwaterEndurance, "4m"),
                new Feature(FeatureEnum.Bluetooth, "4.1"),
            ]
        ),
        new Product(
            Name: "Orion X6",
            CurrentPrice: 299,
            PreviousPrice: 399,
            ShortDescription: "Headphones for immersive listening",
            LongDescription : "Immerse yourself in a world of pure sound with our headphones. Experience crystal-clear audio, deep bass, and noise-canceling technology that blocks out distractions. Whether you're commuting, working out, or simply relaxing, our headphones provide the perfect auditory escape.",
            Rating: 4.7d,
            ThumbnailImageIndex: 0,
            Images:
            [
                "headphones02_1.jpg",
                "headphones02_2.jpg",
            ],
            Features:
            [
                new Feature(FeatureEnum.BatteryEndurance, "7h"),
                new Feature(FeatureEnum.Bluetooth, "5.3"),
                new Feature(FeatureEnum.RandomSpec, "3D"),
            ]
        )
    ];

    public IEnumerable<Product> GetAllProducts() =>
        GetLimitedOfferProducts()
            .Concat(GetPopularProducts().Concat(GetLimitedOfferProducts().Concat(GetPopularProducts())))
            .Select((product, index) => product with { IsEven = index % 2 == 0 })
            .ToList();
}