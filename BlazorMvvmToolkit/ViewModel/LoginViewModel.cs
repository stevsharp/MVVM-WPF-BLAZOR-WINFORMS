using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.ComponentModel.DataAnnotations;

namespace BlazorMvvmToolkit.ViewModel;

public partial class LoginViewModel : ObservableValidator
{
    [ObservableProperty]
    [Required(ErrorMessage = "Username is required")]
    private string username = string.Empty;

    [ObservableProperty]
    [Required(ErrorMessage = "Password is required")]
    private string password = string.Empty;

    [ObservableProperty]
    private string message;

    [RelayCommand]
    private void Login()
    {
        ValidateAllProperties();

        if (HasErrors)
        {
            Message = "Please correct the validation errors.";
            return;
        }

        if (Username == "admin" && Password == "1234")
        {
            Message = "Login successful!";
        }
        else
        {
            Message = "Invalid credentials.";
        }
    }
}