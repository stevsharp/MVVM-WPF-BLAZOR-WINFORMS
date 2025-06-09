
using System;

using WpfAppCommunityMVVM.Model;

namespace WpfAppCommunityMVVM.Repository
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _data = new()
        {
            new Customer { Id = 1, Name = "Alice", Email = "alice@in.gr" },
            new Customer { Id = 2, Name = "Bob", Email = "bob@google.gr" }
        };

        private int _nextId = 3;

        public Task<List<Customer>> GetAllAsync() => Task.FromResult(_data.ToList());

        public Task AddAsync(Customer customer)
        {
            customer.Id = _nextId++;
            _data.Add(customer);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Customer customer)
        {
            var index = _data.FindIndex(c => c.Id == customer.Id);
            if (index >= 0) _data[index] = customer;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);
            if (item != null) _data.Remove(item);
            return Task.CompletedTask;
        }
    }
}
