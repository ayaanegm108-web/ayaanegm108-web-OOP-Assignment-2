namespace SrpLab;

/// <summary>
/// Reason to change: the warehouse layout changes the order in which items are walked.
/// It uses the allocation result instead of recalculating it.
/// </summary>
public sealed class WalkingPathPlanner
{
    public IReadOnlyList<PickStop> Plan(IReadOnlyList<PickLine> lines, IReadOnlyList<StockAllocation> allocations) =>
        lines.Zip(allocations, (line, alloc) => new PickStop(line.Aisle, line.Bin, line.Sku, alloc.Allocated))
             .OrderBy(s => s.Aisle)
             .ThenBy(s => s.Bin)
             .Where(s => s.Qty > 0)
             .ToList();
}
