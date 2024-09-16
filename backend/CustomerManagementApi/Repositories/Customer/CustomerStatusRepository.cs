namespace CustomerManagementApi.Repositories
{
  using CustomerManagementApi.Data;
  using CustomerManagementApi.Models;
  using CustomerManagementApi.Repositories.Interfaces;
  using Microsoft.EntityFrameworkCore;

  public class CustomerStatusRepository : ICustomerStatusRepository
  {
    private readonly ApplicationDbContext _context;

    public CustomerStatusRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<CustomerStatus>> GetAllAsync()
    {
      return await _context.CustomerStatuses.ToListAsync();
    }
  }
}