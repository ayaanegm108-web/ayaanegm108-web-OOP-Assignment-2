namespace SrpLab;

public sealed record TicketItem(string Name, IReadOnlyList<string> Ingredients, int PrepMinutes);
