using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagementApi.Data;
using CustomerManagementApi.DTOs;
using CustomerManagementApi.Services.Interfaces;

namespace CustomerManagementApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerStatusController : ControllerBase
  {
    private readonly ICustomerStatusService _customerStatusService;

    public CustomerStatusController(ICustomerStatusService customerStatusService)
    {
      _customerStatusService = customerStatusService;
    }

    // GET: api/CustomerStatus
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerStatusDTO>>> GetCustomerStatus()
    {
      var customerStatuses = await _customerStatusService.GetAllAsync();
      return Ok(customerStatuses);
    }
  }
}
