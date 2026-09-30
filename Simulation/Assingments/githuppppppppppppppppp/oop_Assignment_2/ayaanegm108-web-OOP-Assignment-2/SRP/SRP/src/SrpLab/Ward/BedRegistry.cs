namespace SrpLab;

/// <summary>
/// Reason to change: the rules for who may occupy a bed (validation, ID cleaning, storage) change.
/// </summary>
public sealed class BedRegistry
{
    private readonly Dictionary<int, BedEntry> _entries = new();

    public IEnumerable<BedEntry> Entries => _entries.Values;

    public void Assign(int bed, string patientId, int acuity)
    {
        if (bed <= 0) throw new ArgumentOutOfRangeException(nameof(bed));
        if (string.IsNullOrWhiteSpace(patientId)) throw new ArgumentException("patient required");

        _entries[bed] = new BedEntry(bed, patientId.Trim().ToUpperInvariant(), acuity);
    }

    public BedEntry? Find(int bed) => _entries.GetValueOrDefault(bed);
}
