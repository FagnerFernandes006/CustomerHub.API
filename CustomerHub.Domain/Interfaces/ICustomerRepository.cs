using CustomerHub.Domain.Entities;

public interface ICustomerRepository
{
    Task<(List<Customer> Customers, int Total)>GetAll(int page, int pageSize);

    Task<Customer?> GetById(Guid id);

    Task Create(Customer customer);

    Task Update(Customer customer);

    Task Delete(Customer customer);
}