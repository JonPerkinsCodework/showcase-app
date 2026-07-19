using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utopia.Api.Models;
using Utopia.Domain.Entities;
using Utopia.Infrastructure;
using Utopia.Infrastructure.Data;

namespace Utopia.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ClientController : ControllerBase
{
    private readonly UtopiaDbContext _db;

    public ClientController(UtopiaDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetAll()
    {
        var clients = await _db.Clients
            .Select(c => new ClientDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                DateOfBirth = c.DateOfBirth,
                Email = c.Email,
                Phone = c.Phone,
                Notes = c.Notes,
                CreatedAt = c.CreatedAt
            })
            .ToListAsync();

        return Ok(clients);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ClientDto>> Get(Guid id)

    {
        var c = await _db.Clients.FindAsync(id);
        if (c is null)
            return NotFound();

        return Ok(new ClientDto
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            DateOfBirth = c.DateOfBirth,
            Email = c.Email,
            Phone = c.Phone,
            Notes = c.Notes,
            CreatedAt = c.CreatedAt
        });
    }

    [HttpPost]
    public async Task<ActionResult<ClientDto>> Create(ClientCreateDto dto)
    {
        var client = new Client
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth,
            Email = dto.Email,
            Phone = dto.Phone,
            Notes = dto.Notes
        };

        _db.Clients.Add(client);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = client.Id }, new ClientDto
        {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            DateOfBirth = client.DateOfBirth,
            Email = client.Email,
            Phone = client.Phone,
            Notes = client.Notes,
            CreatedAt = client.CreatedAt
        });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, ClientUpdateDto dto)
    {
        var client = await _db.Clients.FindAsync(id);
        if (client is null)
            return NotFound();

        client.FirstName = dto.FirstName;
        client.LastName = dto.LastName;
        client.DateOfBirth = dto.DateOfBirth;
        client.Email = dto.Email;
        client.Phone = dto.Phone;
        client.Notes = dto.Notes;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var client = await _db.Clients.FindAsync(id);
        if (client is null)
            return NotFound();

        _db.Clients.Remove(client);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
