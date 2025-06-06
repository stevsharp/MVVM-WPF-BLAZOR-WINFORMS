using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorAppMVVM
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        private int _count;
        public int Count
        {
            get => _count;
            set { _count = value; OnPropertyChanged(); }
        }

        public void Increment() => Count++;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
