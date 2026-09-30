namespace SrpLab;

/// <summary>
/// Reason to change: the printer layout (width, separators, lines) changes.
/// </summary>
public sealed class ThermalTicketPrinter
{
    public string Render(KitchenTicket ticket, int orderNumber, IReadOnlyList<string> allergens, int etaMinutes)
    {
        var width = 32;
        var line = new string('=', width);
        var body = string.Join('\n', ticket.Items.Select(i => $"* {i.Name.ToUpperInvariant()} ({i.PrepMinutes}m)"));
        var allergyLine = allergens.Count == 0 ? "ALLERGENS: none" : "ALLERGENS: " + string.Join(",", allergens);
        return $"{line}\nORDER #{orderNumber}\nETA {etaMinutes} MIN\n{body}\n{allergyLine}\n{line}\n";
    }
}
