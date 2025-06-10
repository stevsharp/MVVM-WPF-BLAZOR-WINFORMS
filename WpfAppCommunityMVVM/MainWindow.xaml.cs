using System.Windows;

using WpfAppCommunityMVVM.ViewModel;

namespace WpfAppCommunityMVVM;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(CustomerGridViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}