namespace SrpLab;

/// <summary>
/// Reason to change: academy marketing changes the content of the welcome packet.
/// </summary>
public sealed class WelcomePacketWriter
{
    public string Write(CourseRoster roster, string studentEmail, string studentName)
    {
        var status = roster.IsSeated(studentEmail)
            ? "confirmed seat"
            : $"waitlist #{roster.WaitlistPosition(studentEmail)}";
        return $"# Welcome to {roster.CourseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
               $"Bring a laptop. Discord onboarding link: https://example.invalid/{roster.CourseCode.ToLowerInvariant()}\n";
    }
}
