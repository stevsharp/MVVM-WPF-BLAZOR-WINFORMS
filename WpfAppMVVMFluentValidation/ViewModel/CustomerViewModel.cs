using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using FluentValidation;

using System.Collections;
using System.ComponentModel;
using System.Windows;

using WpfAppMVVMFluentValidation.Model;
using WpfAppMVVMFluentValidation.Validation;

namespace WpfAppMVVMFluentValidation;

public partial class CustomerViewModel : ObservableObject, INotifyDataErrorInfo
{
    private readonly CustomerValidator _validator = new();
    private readonly Customer _customer = new();

    private readonly Dictionary<string, List<string>> _errors = new();

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    partial void OnNameChanged(string value)
    {
        if (_customer.Name == value)
            return;

        _customer.Name = value;
        ValidateProperty(nameof(Name));
    }

    partial void OnEmailChanged(string value)
    {
        if (_customer.Email == value)
            return;

        _customer.Email = value;
        ValidateProperty(nameof(Email));
    }

    public bool HasErrors => _errors.Any();

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    public IEnumerable GetErrors(string? propertyName)
    {
        if (propertyName is null) return Enumerable.Empty<string>();
        return _errors.TryGetValue(propertyName, out var errors) ? errors : Enumerable.Empty<string>();
    }

    [RelayCommand]
    private void Submit()
    {
        ValidateAllProperties();

        if (!HasErrors)
        {
            MessageBox.Show("Customer data is valid!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void ValidateAllProperties()
    {
        _errors.Clear();
        var results = _validator.Validate(_customer);

        foreach (var error in results.Errors)
        {
            if (!_errors.ContainsKey(error.PropertyName))
                _errors[error.PropertyName] = new List<string>();

            _errors[error.PropertyName].Add(error.ErrorMessage);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(error.PropertyName));
        }
    }

    private void ValidateProperty(string propertyName)
    {
        var results = _validator.Validate(_customer, options => options.IncludeProperties(propertyName));

        if (results.IsValid)
        {
            _errors.Remove(propertyName);
        }
        else
        {
            _errors[propertyName] = results.Errors.Select(e => e.ErrorMessage).ToList();
        }

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

}

