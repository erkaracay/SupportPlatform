using SupportPlatform.Application.DTOs;

namespace SupportPlatform.Application.Interfaces;

public interface ITicketService
{
    Task<List<TicketDto>> GetAllTicketsAsync();
    Task<TicketDto?> GetTicketByIdAsync(Guid id);
    Task<TicketDto> CreateTicketAsync(TicketDto ticketDto);
    Task<TicketDto> UpdateTicketAsync(TicketDto dto);
    Task<bool> DeleteTicketAsync(Guid id);
}
