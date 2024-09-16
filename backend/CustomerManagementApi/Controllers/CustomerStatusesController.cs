using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagementApi.Data;
using CustomerManagementApi.Models;
using CustomerManagementApi.DTOs;

namespace CustomerManagementApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerStatusesController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public CustomerStatusesController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: api/CustomerStatuses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerStatusDTO>>> GetCustomerStatuses()
    {
      var customerStatuses = await _context.CustomerStatuses.ToListAsync();
      return Ok(customerStatuses);
    }
  }
}
