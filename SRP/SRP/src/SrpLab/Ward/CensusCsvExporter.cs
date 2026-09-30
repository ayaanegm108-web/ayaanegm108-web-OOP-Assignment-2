namespace SrpLab;

/// <summary>
/// Reason to change: the columns or format of the census CSV change.
/// </summary>
public sealed class CensusCsvExporter
{
    public string Export(IEnumerable<BedEntry> entries)
    {
        var lines = new List<string> { "bed,patient,acuity" };
        foreach (var entry in entries.OrderBy(e => e.Bed))
            lines.Add($"{entry.Bed},{entry.PatientId},{entry.Acuity}");
        return string.Join('\n', lines);
    }
}
