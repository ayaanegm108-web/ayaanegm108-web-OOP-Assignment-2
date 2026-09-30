namespace SrpLab;

/// <summary>
/// Reason to change: the rules for finding and booking a free slot change.
/// </summary>
public sealed class AppointmentScheduler
{
    private readonly BusinessHours _hours;
    private readonly HashSet<DateTimeOffset> _booked = new();

    public AppointmentScheduler(BusinessHours hours) => _hours = hours;

    public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours)
    {
        var cursor = Align(from);
        var end = from.AddHours(searchHours);
        while (cursor < end)
        {
            if (_hours.IsWithinBusinessHours(cursor) && !_booked.Contains(cursor))
                return cursor;
            cursor = cursor.AddMinutes(_hours.SlotMinutes);
        }
        return null;
    }

    public bool TryBook(DateTimeOffset slot)
    {
        if (!_hours.IsWithinBusinessHours(slot) || _booked.Contains(slot)) return false;
        _booked.Add(slot);
        return true;
    }

    private DateTimeOffset Align(DateTimeOffset from)
    {
        var minutes = from.Minute - (from.Minute % _hours.SlotMinutes);
        return new DateTimeOffset(from.Year, from.Month, from.Day, from.Hour, minutes, 0, from.Offset);
    }
}
