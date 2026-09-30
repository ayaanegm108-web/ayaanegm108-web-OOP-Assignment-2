namespace SrpLab;

/// <summary>
/// Reason to change: customer experience changes the tone or template of the public reply.
/// </summary>
public sealed class PublicReplyWriter
{
    public string Write(SupportTicket ticket, string agentName, DateTimeOffset slaDeadline)
    {
        var apology = ticket.Priority == "P1"
            ? "We are treating this as a critical incident."
            : "Thanks for reaching out.";
        return $"Hi,\n{apology}\nTicket {ticket.Id} is with {agentName}. Next update before {slaDeadline:u}.\n";
    }
}
