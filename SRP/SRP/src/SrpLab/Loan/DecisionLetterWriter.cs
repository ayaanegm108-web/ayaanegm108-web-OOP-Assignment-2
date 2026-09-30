namespace SrpLab;

/// <summary>
/// Reason to change: legal or communications changes the wording of the decision letter.
/// </summary>
public sealed class DecisionLetterWriter
{
    public string Write(LoanApplication app, string applicantName, bool isEligible,
        decimal riskScore, IReadOnlyList<string> requiredDocuments)
    {
        if (isEligible)
        {
            return $"Dear {applicantName},\nYour request for {app.RequestedAmount:C} is pre-approved (risk {riskScore:0}).\n" +
                   $"Please upload: {string.Join("; ", requiredDocuments)}.\n";
        }

        return $"Dear {applicantName},\nWe are unable to approve {app.RequestedAmount:C} at this time.\n" +
               $"Reference risk={riskScore:0}. You may reapply after improving documentation.\n";
    }
}
