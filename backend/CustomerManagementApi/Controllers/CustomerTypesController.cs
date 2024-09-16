using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerManagementApi.Data;
using CustomerManagementApi.Models;

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerType>>> GetCustomerTypes()
    {
      return await _context.CustomerTypes.ToListAsync();
    }
  }
}
