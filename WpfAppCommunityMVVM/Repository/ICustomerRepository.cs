
using System;

using WpfAppCommunityMVVM.Model;

namespace WpfAppCommunityMVVM.Repository;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();
    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
}
