using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfAppMVVM
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        private int _count;
        public int Count
        {
            get => _count;
            set { _count = value; OnPropertyChanged(); }
        }

        public ICommand IncrementCommand { get; }

        public CounterViewModel()
        {
            IncrementCommand = new RelayCommand(_ => Count++);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
