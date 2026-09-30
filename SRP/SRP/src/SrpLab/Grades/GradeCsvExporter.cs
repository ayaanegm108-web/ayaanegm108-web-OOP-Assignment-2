namespace SrpLab;

/// <summary>
/// Reason to change: the columns or format of the grades CSV change.
/// </summary>
public sealed class GradeCsvExporter
{
    public string Export(IEnumerable<StudentResult> results)
    {
        var rows = new List<string> { "studentId,average,letter,honor" };
        foreach (var r in results.OrderBy(x => x.StudentId))
            rows.Add($"{r.StudentId},{r.Average},{r.Letter},{(r.HonorRoll ? 1 : 0)}");
        return string.Join('\n', rows);
    }
}
