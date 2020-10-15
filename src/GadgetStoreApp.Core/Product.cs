using System;
using System.Collections.Generic;

namespace GadgetStoreApp.Core
{
    public class Product
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public double CurrentPrice { get; set; }
        public double PreviousPrice { get; set; }
        public double Discount => (Math.Round((PreviousPrice - CurrentPrice) / PreviousPrice, 1)) * 100;
        public double Rating { get; set; }
        public bool Favorite { get; set; }
        public List<string> Images { get; set; }
        public int ThumbnailImageIndex { get; set; }
        public List<Feature> Features { get; set; }
        public string Thumbnail { get => Images[ThumbnailImageIndex]; }
    }

    public class Feature
    {
        public FeatureEnum FeatureEnum { get; set; }
        public string Value { get; set; }
    }

    public enum FeatureEnum
    {
        BatteryEndurance, UnderwaterEndurance, Bluetooth, RandomSpec
    }
}
