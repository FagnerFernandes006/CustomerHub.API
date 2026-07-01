using CustomerHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository
: ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(
        AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(Customer customer)
    {
        await _context.Customers.AddAsync(customer);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Customer>> GetAll()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetById(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task Update(Customer customer)
    {
        _context.Update(customer);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(Customer customer)
    {
        _context.Remove(customer);

        await _context.SaveChangesAsync();
    }
}