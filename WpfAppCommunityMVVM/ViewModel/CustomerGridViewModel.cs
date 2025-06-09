using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


using WpfAppCommunityMVVM.Model;
using WpfAppCommunityMVVM.Repository;

namespace WpfAppCommunityMVVM.ViewModel;

public partial class CustomerGridViewModel : ObservableObject
{
    private readonly ICustomerRepository _repository;

    public CustomerGridViewModel(ICustomerRepository repository)
    {
        _repository = repository;
        Customers = new();
        LoadCommand.Execute(null);
    }

    [ObservableProperty]
    private ObservableCollection<Customer> customers;

    [ObservableProperty]
    private Customer? selectedCustomer;

    [RelayCommand]
    private async Task LoadAsync()
    {
        var list = await _repository.GetAllAsync();
        Customers = new ObservableCollection<Customer>(list);
    }

    [RelayCommand]
    private void New()
    {
        var newCustomer = new Customer();
        Customers.Add(newCustomer);
        SelectedCustomer = newCustomer;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (SelectedCustomer == null) return;

        if (SelectedCustomer.Id == 0)
            await _repository.AddAsync(SelectedCustomer);
        else
            await _repository.UpdateAsync(SelectedCustomer);
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (SelectedCustomer == null || SelectedCustomer.Id == 0) return;

        await _repository.DeleteAsync(SelectedCustomer.Id);
        Customers.Remove(SelectedCustomer);
        SelectedCustomer = null;
    }
}
