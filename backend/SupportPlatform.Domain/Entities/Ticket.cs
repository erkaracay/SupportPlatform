namespace SupportPlatform.Domain.Entities;

public enum TicketStatus
{
    Open,
    InProgress,
    Closed,
}

public enum TicketPriority
{
    Low,
    Medium,
    High,
}

public class Ticket
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public TicketStatus Status { get; set; } = TicketStatus.Open;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;

    public Guid CompanyId { get; set; }
    public Guid CreatedByUserId { get; set; }

    // İlişkiler ileride eklenebilir
    // public Company? Company { get; set; }
    // public User? CreatedBy { get; set; }
}
