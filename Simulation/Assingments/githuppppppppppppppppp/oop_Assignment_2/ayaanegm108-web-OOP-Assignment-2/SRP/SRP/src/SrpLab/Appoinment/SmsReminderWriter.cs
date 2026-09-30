namespace SrpLab;

/// <summary>
/// Reason to change: patient communications change the wording of the SMS reminder.
/// </summary>
public sealed class SmsReminderWriter
{
    public string Write(DateTimeOffset slot, string clinicPhone) =>
        $"Reminder: appointment {slot:MMM dd HH:mm}. Call {clinicPhone} to reschedule.";
}
