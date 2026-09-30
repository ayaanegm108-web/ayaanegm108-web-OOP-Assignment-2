namespace SrpLab;

/// <summary>
/// Reason to change: the WMS integration contract (XML shape) changes.
/// </summary>
public sealed class WmsXmlBatchWriter
{
    public string Write(string batchId, IReadOnlyList<StockAllocation> allocations)
    {
        var parts = allocations.Select(a => $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");
        return $"<batch id=\"{batchId}\">{string.Join("", parts)}</batch>";
    }
}
