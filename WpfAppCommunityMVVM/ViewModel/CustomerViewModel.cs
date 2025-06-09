

namespace WpfAppCommunityMVVM.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WpfAppCommunityMVVM.Model;

public partial class CustomerViewModel : ObservableObject
{
    public int Id { get; }

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    public CustomerViewModel(Customer model)
    {
        Id = model.Id;
        name = model.Name;
        email = model.Email;
    }

    public Customer ToModel() => new Customer { Id = Id, Name = Name, Email = Email };
}

