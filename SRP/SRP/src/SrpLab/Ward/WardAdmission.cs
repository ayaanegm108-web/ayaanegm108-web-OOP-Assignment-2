namespace SrpLab;

/// <summary>
/// Reason to change: the order of the steps when a patient is admitted to a bed changes.
/// It only coordinates; every rule lives in the classes it calls.
/// </summary>
public sealed class WardAdmission
{
    private readonly BedRegistry _beds;
    private readonly AcuityScorer _scorer;
    private readonly PagerAlertLog _pager;

    public WardAdmission(BedRegistry beds, AcuityScorer scorer, PagerAlertLog pager)
    {
        _beds = beds;
        _scorer = scorer;
        _pager = pager;
    }

    public void Admit(int bed, string patientId, int heartRate, int spo2, DateTime nowUtc)
    {
        var acuity = _scorer.Score(heartRate, spo2);
        _beds.Assign(bed, patientId, acuity);
        _pager.RecordIfNeeded(bed, acuity, nowUtc);
    }
}
