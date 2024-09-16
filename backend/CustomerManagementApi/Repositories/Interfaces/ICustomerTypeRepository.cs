namespace CustomerManagementApi.Repositories.Interfaces
{
  using CustomerManagementApi.Models;
  
  public interface ICustomerTypeRepository
  {
    Task<IEnumerable<CustomerType>> GetAllAsync();
  }
}