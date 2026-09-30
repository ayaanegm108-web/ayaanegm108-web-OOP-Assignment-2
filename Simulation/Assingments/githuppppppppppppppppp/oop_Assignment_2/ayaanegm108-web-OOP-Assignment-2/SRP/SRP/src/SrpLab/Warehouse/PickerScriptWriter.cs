namespace SrpLab;

/// <summary>
/// Reason to change: the handheld UX team changes the wording of picker instructions.
/// </summary>
public sealed class PickerScriptWriter
{
    public string Write(IReadOnlyList<PickStop> stops, IReadOnlyList<StockAllocation> allocations)
    {
        var steps = stops.Select((s, i) => $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}");
        var shortSkus = allocations.Where(a => a.IsShort).Select(a => a.Sku).ToList();
        var warn = shortSkus.Count > 0
            ? "SHORTAGES: " + string.Join(", ", shortSkus)
            : "SHORTAGES: none";
        return string.Join('\n', steps) + "\n" + warn;
    }
}
