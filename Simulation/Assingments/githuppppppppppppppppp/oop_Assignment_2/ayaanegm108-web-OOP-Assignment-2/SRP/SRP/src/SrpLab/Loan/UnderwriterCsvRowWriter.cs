namespace SrpLab;

/// <summary>
/// Reason to change: the analytics team changes the columns of the underwriter export.
/// </summary>
public sealed class UnderwriterCsvRowWriter
{
    public string Write(LoanApplication app, string applicationId, decimal riskScore, bool isEligible) =>
        $"{applicationId},{app.CreditScore},{app.EmploymentMonths},{(app.HasCollateral ? 1 : 0)},{riskScore:0.00},{(isEligible ? "Y" : "N")}";
}
