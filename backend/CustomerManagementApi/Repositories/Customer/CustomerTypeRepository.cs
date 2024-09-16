namespace CustomerManagementApi.Repositories.CustomerType
{
  using CustomerManagementApi.Data;
  using CustomerManagementApi.Models;
  using CustomerManagementApi.Repositories.Interfaces;
  using Microsoft.EntityFrameworkCore;

  public class CustomerTypeRepository : ICustomerTypeRepository
  {
    private readonly ApplicationDbContext _context;

    public CustomerTypeRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<CustomerType>> GetAllAsync()
    {
      return await _context.CustomerTypes.ToListAsync();
    }
  }
}