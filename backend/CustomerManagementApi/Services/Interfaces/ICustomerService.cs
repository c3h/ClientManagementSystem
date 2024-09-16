using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementApi.DTOs;
using CustomerManagementApi.Models;

namespace CustomerManagementApi.Services.Interfaces
{
  public interface ICustomerService
  {
    Task<PagedResult<CustomerDTO>> GetAllAsync(int pageNumber, int pageSize);
    Task<CustomerDTO> GetByIdAsync(int id);
    Task<CustomerDTO> AddAsync(CustomerDTO customerDto);
    Task UpdateAsync(int id, CustomerDTO customerDto);
    Task DeleteAsync(int id);
  }
}
