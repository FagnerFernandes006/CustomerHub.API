using Microsoft.EntityFrameworkCore;
using CustomerHub.Domain.Entities;

public class AppDbContext
: DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers =>
        Set<Customer>();
}