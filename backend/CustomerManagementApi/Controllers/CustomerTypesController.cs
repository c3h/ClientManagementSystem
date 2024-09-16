using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagementApi.Data;
using CustomerManagementApi.Models;
using CustomerManagementApi.DTOs;

namespace CustomerManagementApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerTypesController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public CustomerTypesController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: api/CustomerTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerTypeDTO>>> GetCustomerTypes()
    {
      var customerTypes = await _context.CustomerTypes.ToListAsync();
      return Ok(customerTypes);
    }
  }
}
