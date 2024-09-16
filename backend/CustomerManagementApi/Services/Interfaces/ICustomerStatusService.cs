namespace CustomerManagementApi.Services.Interfaces
{
  using CustomerManagementApi.DTOs;

  public interface ICustomerStatusService
  {
    Task<IEnumerable<CustomerStatusDTO>> GetAllAsync();
  }
}