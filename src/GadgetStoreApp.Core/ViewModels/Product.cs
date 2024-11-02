namespace GadgetStoreApp.Core;

public record Product(
    string Name,
    string ShortDescription,
    string LongDescription,
    double CurrentPrice,
    double PreviousPrice,
    double Rating,
    List<string> Images,
    int ThumbnailImageIndex,
    List<Feature> Features,
    bool IsEven = false
)
{
    public bool HasDiscount => CurrentPrice < PreviousPrice;
    public double Discount => Math.Round((PreviousPrice - CurrentPrice) / PreviousPrice, 1) * 100;
    public string Thumbnail => Images[ThumbnailImageIndex];
    public bool Favorite { get; set; } = false;
}

public record Feature(FeatureEnum FeatureEnum, string Value);

public enum FeatureEnum
{
    BatteryEndurance, UnderwaterEndurance, Bluetooth, RandomSpec
}