namespace CustomerManagementApi.Services.Interfaces
{
  using CustomerManagementApi.DTOs;
  
  public interface ICustomerTypeService
  {
    Task<IEnumerable<CustomerTypeDTO>> GetAllAsync();
  }
}