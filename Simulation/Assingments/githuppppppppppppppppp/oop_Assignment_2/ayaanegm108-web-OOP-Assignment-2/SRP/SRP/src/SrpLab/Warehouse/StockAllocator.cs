namespace SrpLab;

/// <summary>
/// Reason to change: the allocation / backorder policy changes.
/// </summary>
public sealed class StockAllocator
{
    public IReadOnlyList<StockAllocation> Allocate(IReadOnlyList<PickLine> lines) =>
        lines.Select(l => new StockAllocation(l.Sku, Math.Min(l.QtyNeeded, l.QtyOnHand), l.QtyNeeded)).ToList();
}
