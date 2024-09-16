using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagementApi.Data;
using CustomerManagementApi.Models;

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerStatus>>> GetCustomerStatuses()
    {
      return await _context.CustomerStatuses.ToListAsync();
    }
  }
}
