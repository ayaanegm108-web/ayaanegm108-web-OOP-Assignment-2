namespace SrpLab;

/// <summary>
/// Reason to change: the wording or layout of the nurse handoff note changes.
/// </summary>
public sealed class HandoffNoteFormatter
{
    public string Format(int bed, BedEntry? entry, DateTime nowUtc)
    {
        if (entry is null)
            return $"Bed {bed}: empty";

        var tone = entry.Acuity >= 8 ? "ESCALATE" : entry.Acuity >= 4 ? "WATCH" : "STABLE";
        return $"[HANDOFF {nowUtc:yyyy-MM-dd}] Bed {bed} · {entry.PatientId} · acuity={entry.Acuity} · {tone}";
    }
}
