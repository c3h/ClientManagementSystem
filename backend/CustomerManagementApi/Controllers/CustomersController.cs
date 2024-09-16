using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CustomerManagementApi.DTOs;
using CustomerManagementApi.Services.Interfaces;
using CustomerManagementApi.Models;

namespace CustomerManagementApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomersController : ControllerBase
  {
    private readonly ICustomerService _customerService;
    private readonly ILogger<CustomersController> _logger;

    public CustomersController(ICustomerService customerService, ILogger<CustomersController> logger)
    {
      _customerService = customerService;
      _logger = logger;
    }

    // GET: api/Customers
    [HttpGet]
    public async Task<ActionResult<PagedResult<CustomerDTO>>> GetCustomers(int pageNumber = 1, int pageSize = 10)
    {
      var result = await _customerService.GetAllAsync(pageNumber, pageSize);
      return Ok(result);
    }

    // GET: api/Customers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
    {
      var customerDto = await _customerService.GetByIdAsync(id);

      if (customerDto == null)
      {
        return NotFound();
      }

      return customerDto;
    }

    // POST: api/Customers
    [HttpPost]
    public async Task<ActionResult<CustomerDTO>> PostCustomer(CreateCustomerDTO createCustomerDTO)
    {
      var createdCustomerDto = await _customerService.AddAsync(createCustomerDTO);
      _logger.LogInformation("Customer created with ID: {Id}", createdCustomerDto.Id);

      return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomerDto.Id }, createdCustomerDto);
    }

    // PUT: api/Customers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCustomer(int id, UpdateCustomerDTO updateCustomerDTO)
    {
      try
      {
        await _customerService.UpdateAsync(id, updateCustomerDTO);
      }
      catch (System.Exception ex)
      {
        _logger.LogError(ex, "Error updating customer with ID: {Id}", id);
        throw;
      }

      return NoContent();
    }

    // DELETE: api/Customers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
      await _customerService.DeleteAsync(id);
      _logger.LogInformation("Customer deleted with ID: {Id}", id);
      return NoContent();
    }
  }
}
