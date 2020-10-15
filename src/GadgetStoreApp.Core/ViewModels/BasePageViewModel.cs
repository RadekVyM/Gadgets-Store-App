using System.ComponentModel;
using System.Windows.Input;

namespace GadgetStoreApp.Core
{
    public class BasePageViewModel : INotifyPropertyChanged, IBasePageViewModel
    {
        public ICommand GoBackCommand { get; protected set; }

        public BasePageViewModel(INavigationService navigationService)
        {
            GoBackCommand = new RelayCommand(() => navigationService.Pop());
        }

        public virtual void OnPagePushing(params object[] parameters) { }

        public void OnPropertyChanged(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}