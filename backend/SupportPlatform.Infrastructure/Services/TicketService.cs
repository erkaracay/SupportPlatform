using Microsoft.EntityFrameworkCore;
using SupportPlatform.Application.DTOs;
using SupportPlatform.Application.Interfaces;
using SupportPlatform.Domain.Entities;
using SupportPlatform.Infrastructure.Persistence;

namespace SupportPlatform.Infrastructure.Services;

public class TicketService : ITicketService
{
    private readonly AppDbContext _context;

    public TicketService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TicketDto>> GetAllTicketsAsync()
    {
        return await _context
            .Tickets.Select(t => new TicketDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedAt = t.CreatedAt,
                Status = t.Status.ToString(),
                Priority = t.Priority.ToString(),
                CompanyId = t.CompanyId,
                CreatedByUserId = t.CreatedByUserId,
            })
            .ToListAsync();
    }

    public async Task<TicketDto?> GetTicketByIdAsync(Guid id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
            return null;

        return new TicketDto
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            CreatedAt = ticket.CreatedAt,
            Status = ticket.Status.ToString(),
            Priority = ticket.Priority.ToString(),
            CompanyId = ticket.CompanyId,
            CreatedByUserId = ticket.CreatedByUserId,
        };
    }

    public async Task<TicketDto> CreateTicketAsync(TicketDto dto)
    {
        var ticket = new Ticket
        {
            Title = dto.Title,
            Description = dto.Description,
            Priority = Enum.Parse<TicketPriority>(dto.Priority),
            Status = Enum.Parse<TicketStatus>(dto.Status),
            CompanyId = dto.CompanyId,
            CreatedByUserId = dto.CreatedByUserId,
        };

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();

        dto.Id = ticket.Id;
        dto.CreatedAt = ticket.CreatedAt;
        return dto;
    }

    public async Task<TicketDto> UpdateTicketAsync(TicketDto dto)
    {
        var ticket = await _context.Tickets.FindAsync(dto.Id);
        if (ticket == null)
            throw new Exception("Ticket not found");

        ticket.Title = dto.Title;
        ticket.Description = dto.Description;
        ticket.Priority = Enum.Parse<TicketPriority>(dto.Priority);
        ticket.Status = Enum.Parse<TicketStatus>(dto.Status);
        ticket.CompanyId = dto.CompanyId;
        ticket.CreatedByUserId = dto.CreatedByUserId;

        await _context.SaveChangesAsync();
        return dto;
    }

    public async Task<bool> DeleteTicketAsync(Guid id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
            return false;

        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
        return true;
    }
}
