using CustomerHub.Application.DTOs;
using CustomerHub.Domain.Entities;

public class CustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(
        ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(
        CreateCustomerDto dto)
    {
        var customer = new Customer
        {
            Name = dto.Name,
            Email = dto.Email
        };

        await _repository.Create(customer);
    }

    public async Task<List<CustomerResponseDto>> GetAll()
    {
        var customers =
            await _repository.GetAll();

        return customers
            .Select(x =>
                new CustomerResponseDto(
                    x.Id,
                    x.Name,
                    x.Email))
            .ToList();
    }

    public async Task<CustomerResponseDto?> GetById(
        Guid id)
    {
        var customer =
            await _repository.GetById(id);

        if (customer == null)
            return null;

        return new CustomerResponseDto(
            customer.Id,
            customer.Name,
            customer.Email);
    }

    public async Task<bool> Update(
        Guid id,
        UpdateCustomerDto dto)
    {
        var customer =
            await _repository.GetById(id);

        if (customer == null)
            return false;

        customer.Name = dto.Name;
        customer.Email = dto.Email;

        await _repository.Update(customer);

        return true;
    }

    public async Task<bool> Delete(
        Guid id)
    {
        var customer =
            await _repository.GetById(id);

        if (customer == null)
            return false;

        await _repository.Delete(customer);

        return true;
    }
}