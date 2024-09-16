using AutoMapper;
using CustomerManagementApi.Models;
using CustomerManagementApi.DTOs;

namespace CustomerManagementApi.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Customer, CustomerDTO>().ReverseMap();
    }
  }
}
