using CustomerHub.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _service;

    public CustomersController(
        CustomerService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCustomerDto dto)
    {
        try
        {
            var customer =
                await _service.Create(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = customer.Id },
                customer);
        }
        catch (Exception ex)
        {
            return BadRequest(
                new
                {
                    error = ex.Message
                });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers =
            await _service.GetAll();

        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {
        var customer =
            await _service.GetById(id);

        if (customer == null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateCustomerDto dto)
    {
        try
        {
            var updated =
                await _service.Update(
                    id,
                    dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(
                new
                {
                    error = ex.Message
                });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {
        var deleted =
            await _service.Delete(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}