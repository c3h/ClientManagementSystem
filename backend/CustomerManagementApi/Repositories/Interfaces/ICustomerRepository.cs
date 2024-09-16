namespace CustomerManagementApi.Repositories.Interfaces
{
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using CustomerManagementApi.Models;

  public interface ICustomerRepository
  {
    Task<IEnumerable<Customer>> GetAllAsync(int pageNumber, int pageSize);
    Task<Customer> GetByIdAsync(int id);
    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
    Task<bool> ExistsByCpfAsync(string cpf, int? excludeId = null);
    Task<int> GetTotalCountAsync();
  }
}
