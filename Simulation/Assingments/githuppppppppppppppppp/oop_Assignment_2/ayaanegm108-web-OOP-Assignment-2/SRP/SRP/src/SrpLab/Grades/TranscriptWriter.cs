namespace SrpLab;

/// <summary>
/// Reason to change: the registrar changes the layout of the plain-text transcript.
/// </summary>
public sealed class TranscriptWriter
{
    public string Write(StudentResult result, string fullName) =>
        $"TRANSCRIPT\nStudent: {fullName} ({result.StudentId})\nAverage: {result.Average}\nLetter: {result.Letter}\nHonor: {result.HonorRoll}\n";
}
