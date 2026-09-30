namespace SrpLab;

/// <summary>
/// Reason to change: the SLA hours per priority, or the breach rule, change.
/// </summary>
public sealed class SlaDeadlineCalculator
{
    public DateTimeOffset Deadline(SupportTicket ticket)
    {
        var hours = ticket.Priority switch
        {
            "P1" => 4,
            "P2" => 24,
            _ => 72
        };
        return ticket.OpenedAt.AddHours(hours);
    }

    public bool IsBreached(SupportTicket ticket, DateTimeOffset now) => now > Deadline(ticket);
}
