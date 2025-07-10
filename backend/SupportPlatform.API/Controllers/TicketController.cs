using Microsoft.AspNetCore.Mvc;
using SupportPlatform.Application.DTOs;
using SupportPlatform.Application.Interfaces;

namespace SupportPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    // GET: /api/ticket
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tickets = await _ticketService.GetAllTicketsAsync();
        return Ok(tickets);
    }

    // GET: /api/ticket/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);
        if (ticket == null)
            return NotFound();
        return Ok(ticket);
    }

    // POST: /api/ticket
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TicketDto ticketDto)
    {
        var createdTicket = await _ticketService.CreateTicketAsync(ticketDto);
        return CreatedAtAction(nameof(GetById), new { id = createdTicket.Id }, createdTicket);
    }
}
