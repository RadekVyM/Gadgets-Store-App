namespace GadgetStoreApp.Maui.Extensions
{
    public static class ResourceExtensions
    {
        public static T GetValue<T>(this ResourceDictionary dictionary, string key)
        {
            object value;

            dictionary.TryGetValue(key, out value);

            return (T)value;
        }
    }
}
