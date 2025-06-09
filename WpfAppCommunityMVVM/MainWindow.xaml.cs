using CommunityToolkit.Mvvm.ComponentModel;

using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WpfAppCommunityMVVM.Repository;
using WpfAppCommunityMVVM.ViewModel;

namespace WpfAppCommunityMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CustomerGridViewModel(new InMemoryCustomerRepository());
        }
    }
}