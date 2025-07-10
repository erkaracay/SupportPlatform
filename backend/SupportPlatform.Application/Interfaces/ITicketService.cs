using SupportPlatform.Application.DTOs;

namespace SupportPlatform.Application.Interfaces;

public interface ITicketService
{
    Task<List<TicketDto>> GetAllTicketsAsync();
    Task<TicketDto?> GetTicketByIdAsync(Guid id);
    Task<TicketDto> CreateTicketAsync(TicketDto ticketDto);
}
