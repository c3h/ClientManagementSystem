using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagementApi.Data;
using CustomerManagementApi.Models;
using CustomerManagementApi.DTOs;
using CustomerManagementApi.Services.Interfaces;

namespace CustomerManagementApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerTypesController : ControllerBase
  {
    private readonly ICustomerTypeService _customerTypeService;

    public CustomerTypesController(ICustomerTypeService customerTypeService)
    {
      _customerTypeService = customerTypeService;
    }

    // GET: api/CustomerTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerTypeDTO>>> GetCustomerTypes()
    {
      var customerTypes = await _customerTypeService.GetAllAsync();
      return Ok(customerTypes);
    }
  }
}
