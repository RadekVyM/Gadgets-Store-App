namespace GadgetStoreApp.Core
{
    public interface INavigationService
    {
        void Push(PageEnum page, params object[] parameters);
        void Pop();
        void OpenFlyout();
    }
}
