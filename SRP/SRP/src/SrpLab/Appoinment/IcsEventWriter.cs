namespace SrpLab;

/// <summary>
/// Reason to change: calendar clients require a different ICS format.
/// The unique id is passed in, so the output is predictable.
/// </summary>
public sealed class IcsEventWriter
{
    public string Write(Guid uid, DateTimeOffset slot, int slotMinutes, string patientName, string clinician)
    {
        var end = slot.AddMinutes(slotMinutes);
        return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
               $"UID:{uid}\nDTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\nDTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
               $"SUMMARY:Visit {patientName} / {clinician}\nEND:VEVENT\nEND:VCALENDAR\n";
    }
}
