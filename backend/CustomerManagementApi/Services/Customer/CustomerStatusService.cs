using AutoMapper;
using CustomerManagementApi.DTOs;
using CustomerManagementApi.Services.Interfaces;
using CustomerManagementApi.Repositories.Interfaces;

namespace CustomerManagementApi.Services
{
  public class CustomerStatusService : ICustomerStatusService
  {
    private readonly ICustomerStatusRepository _customerStatusRepository;
    private readonly IMapper _mapper;

    public CustomerStatusService(ICustomerStatusRepository customerStatusRepository, IMapper mapper)
    {
      _customerStatusRepository = customerStatusRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerStatusDTO>> GetAllAsync()
    {
      var customerStatuses = await _customerStatusRepository.GetAllAsync();
      return _mapper.Map<IEnumerable<CustomerStatusDTO>>(customerStatuses);
    }
  }
}