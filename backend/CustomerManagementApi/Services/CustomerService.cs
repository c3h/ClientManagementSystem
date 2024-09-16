using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagementApi.DTOs;
using CustomerManagementApi.Models;
using CustomerManagementApi.Repositories.Interfaces;
using CustomerManagementApi.Services.Interfaces;

namespace CustomerManagementApi.Services
{
  public class CustomerService : ICustomerService
  {
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
      _customerRepository = customerRepository;
      _mapper = mapper;
    }

    public async Task<PagedResult<CustomerDTO>> GetAllAsync(int pageNumber, int pageSize)
    {
      var totalItems = await _customerRepository.GetTotalCountAsync();
      var customers = await _customerRepository.GetAllAsync(pageNumber, pageSize);

      var customerDtos = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

      var result = new PagedResult<CustomerDTO>
      {
        TotalItems = totalItems,
        Items = customerDtos
      };

      return result;
    }

    public async Task<CustomerDTO> GetByIdAsync(int id)
    {
      var customer = await _customerRepository.GetByIdAsync(id);
      return _mapper.Map<CustomerDTO>(customer);
    }

    public async Task<CustomerDTO> AddAsync(CreateCustomerDTO createCustomerDTO)
    {
      if (await _customerRepository.ExistsByCpfAsync(createCustomerDTO.CPF))
      {
        throw new Exception("CPF already exists.");
      }

      var customer = _mapper.Map<Customer>(createCustomerDTO);
      await _customerRepository.AddAsync(customer);
      return _mapper.Map<CustomerDTO>(customer);
    }


    public async Task UpdateAsync(int id, UpdateCustomerDTO updateCustomerDTO)
    {
      var customer = _mapper.Map<Customer>(updateCustomerDTO);
      customer.Id = id;
      await _customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteAsync(int id)
    {
      await _customerRepository.DeleteAsync(id);
    }
  }
}
