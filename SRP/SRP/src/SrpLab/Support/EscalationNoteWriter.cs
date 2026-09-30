namespace SrpLab;

/// <summary>
/// Reason to change: the format of the internal escalation line changes.
/// </summary>
public sealed class EscalationNoteWriter
{
    public string Write(SupportTicket ticket, DateTimeOffset slaDeadline) =>
        $"ESCALATE {ticket.Id} priority={ticket.Priority} breachAt={slaDeadline:u} keywords-scanned=yes";
}
