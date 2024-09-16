namespace CustomerManagementApi.Repositories
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.EntityFrameworkCore;
  using CustomerManagementApi.Data;
  using CustomerManagementApi.Models;
  using CustomerManagementApi.Repositories.Interfaces;

  public class CustomerRepository : ICustomerRepository
  {
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync(int pageNumber, int pageSize)
    {
      return await _context.Customers
        .Include(c => c.CustomerType)
        .Include(c => c.CustomerStatus)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
      return await _context.Customers
        .Include(c => c.CustomerType)
        .Include(c => c.CustomerStatus)
        .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Customer customer)
    {
      _context.Customers.Add(customer);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
      _context.Customers.Update(customer);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var customer = await _context.Customers.FindAsync(id);
      if (customer != null)
      {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<bool> ExistsByCpfAsync(string cpf, int? excludeId = null)
    {
      return await _context.Customers
        .AnyAsync(c => c.CPF == cpf && (!excludeId.HasValue || c.Id != excludeId.Value));
    }

    public async Task<int> GetTotalCountAsync()
    {
      return await _context.Customers.CountAsync();
    }
  }
}
