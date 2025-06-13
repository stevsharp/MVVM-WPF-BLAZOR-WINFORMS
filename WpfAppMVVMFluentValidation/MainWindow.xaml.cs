
using System.Windows;

namespace WpfAppMVVMFluentValidation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new CustomerViewModel();
        }
    }
}