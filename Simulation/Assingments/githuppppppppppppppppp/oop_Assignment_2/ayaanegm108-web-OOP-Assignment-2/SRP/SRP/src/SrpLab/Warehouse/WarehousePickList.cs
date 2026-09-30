namespace SrpLab;

/// <summary>
/// Reason to change: what a pick list stores for each needed item changes.
/// </summary>
public sealed class WarehousePickList
{
    private readonly List<PickLine> _lines = new();

    public IReadOnlyList<PickLine> Lines => _lines.AsReadOnly();

    public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand) =>
        _lines.Add(new PickLine(sku, aisle, bin, qtyNeeded, qtyOnHand));
}
