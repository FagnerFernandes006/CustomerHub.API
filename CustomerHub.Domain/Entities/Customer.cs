using System.ComponentModel.DataAnnotations;

namespace CustomerHub.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    protected Customer()
    {
    }

    public Customer(
        string name,
        string email)
    {
        Id = Guid.NewGuid();

        Update(name, email);
    }

    public void Update(
        string name,
        string email)
    {
        Validate(name, email);

        Name = name;

        Email = email;
    }

    private static void Validate(
        string name,
        string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception(
                "Nome é obrigatório");

        if (string.IsNullOrWhiteSpace(email))
            throw new Exception(
                "Email é obrigatório");

        var validator =
            new EmailAddressAttribute();

        if (!validator.IsValid(email))
            throw new Exception(
                "Email inválido");
    }
}