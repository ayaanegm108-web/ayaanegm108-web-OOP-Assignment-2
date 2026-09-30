namespace SrpLab;

/// <summary>
/// Reason to change: the rules for recording scores (valid range, storage per student) change.
/// </summary>
public sealed class GradeBook
{
    private readonly Dictionary<string, List<decimal>> _scores = new(StringComparer.OrdinalIgnoreCase);

    public IEnumerable<string> StudentIds => _scores.Keys;

    public void Record(string studentId, decimal score)
    {
        if (score is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(score));
        if (!_scores.TryGetValue(studentId, out var list))
        {
            list = new List<decimal>();
            _scores[studentId] = list;
        }
        list.Add(score);
    }

    public IReadOnlyList<decimal> ScoresFor(string studentId) =>
        _scores.TryGetValue(studentId, out var list) ? list.AsReadOnly() : Array.Empty<decimal>();
}
