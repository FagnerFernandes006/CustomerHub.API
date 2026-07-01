using System.ComponentModel.DataAnnotations;
using CustomerHub.Domain.Exceptions;

namespace CustomerHub.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    protected Customer()
    {
    }

    public Customer(string name, string email)
    {
        Id = Guid.NewGuid();

        ChangeName(name);

        ChangeEmail(email);
    }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Nome é obrigatório");

        Name = name.Trim();
    }

    public void ChangeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email é obrigatório");

        var validator = new EmailAddressAttribute();

        if (!validator.IsValid(email))
            throw new DomainException("Email inválido");

        Email = email.Trim().ToLower();
    }

    public void Update(string name, string email)
    {
        ChangeName(name);

        ChangeEmail(email);
    }
}