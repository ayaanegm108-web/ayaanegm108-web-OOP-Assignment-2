namespace SrpLab;

/// <summary>
/// Reason to change: what a ticket stores and how its messages are appended changes.
/// The priority rules are supplied by <see cref="TicketPriorityClassifier"/>.
/// </summary>
public sealed class SupportTicket
{
    private readonly TicketPriorityClassifier _classifier;

    public string Id { get; }
    public string Subject { get; }
    public string Body { get; private set; }
    public DateTimeOffset OpenedAt { get; }
    public string Priority { get; private set; }

    public SupportTicket(string id, string subject, string body, DateTimeOffset openedAt,
        TicketPriorityClassifier classifier)
    {
        _classifier = classifier;
        Id = id;
        Subject = subject;
        Body = body;
        OpenedAt = openedAt;
        Priority = _classifier.Classify(Subject, Body);
    }

    public void AppendCustomerMessage(string text)
    {
        Body += "\n---\n" + text;
        Priority = _classifier.Classify(Subject, Body);
    }
}
