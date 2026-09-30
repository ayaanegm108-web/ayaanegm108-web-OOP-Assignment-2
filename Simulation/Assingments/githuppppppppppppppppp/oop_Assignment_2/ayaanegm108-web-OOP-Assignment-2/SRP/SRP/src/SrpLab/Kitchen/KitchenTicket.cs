namespace SrpLab;

/// <summary>
/// Reason to change: what a kitchen ticket stores (items, cleaned ingredients, prep times) changes.
/// </summary>
public sealed class KitchenTicket
{
    private readonly List<TicketItem> _items = new();

    public IReadOnlyList<TicketItem> Items => _items.AsReadOnly();

    public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
    {
        _items.Add(new TicketItem(item, ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList(), prepMinutes));
    }
}
