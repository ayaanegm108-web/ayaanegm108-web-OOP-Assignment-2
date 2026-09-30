namespace SrpLab;

/// <summary>
/// Reason to change: kitchen operations change which expo lane a ticket goes to.
/// </summary>
public sealed class ExpoLaneSelector
{
    public string Choose(bool hasAllergens, int etaMinutes) =>
        hasAllergens ? "LANE-ALLERGY" : etaMinutes > 20 ? "LANE-SLOW" : "LANE-FAST";
}
