using AutoMapper;
using CustomerManagementApi.DTOs;
using CustomerManagementApi.Repositories.Interfaces;
using CustomerManagementApi.Services.Interfaces;

namespace CustomerManagementApi.Services.Customer
{
  public class CustomerTypeService : ICustomerTypeService
  {
    private readonly ICustomerTypeRepository _customerTypeRepository;
    private readonly IMapper _mapper;

    public CustomerTypeService(ICustomerTypeRepository customerTypeRepository, IMapper mapper)
    {
      _customerTypeRepository = customerTypeRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerTypeDTO>> GetAllAsync()
    {
      var customerTypes = await _customerTypeRepository.GetAllAsync();
      return _mapper.Map<IEnumerable<CustomerTypeDTO>>(customerTypes);
    }
  }
}