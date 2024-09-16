namespace CustomerManagementApi.Repositories.Interfaces
{
  using CustomerManagementApi.Models;

  public interface ICustomerStatusRepository
  {
    Task<IEnumerable<CustomerStatus>> GetAllAsync();
  }
}