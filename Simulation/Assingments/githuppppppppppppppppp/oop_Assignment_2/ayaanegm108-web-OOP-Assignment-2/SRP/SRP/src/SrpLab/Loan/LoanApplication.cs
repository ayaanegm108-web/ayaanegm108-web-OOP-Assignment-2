namespace SrpLab;

/// <summary>What the applicant asked for and their basic profile.</summary>
public sealed record LoanApplication(decimal RequestedAmount, int CreditScore, int EmploymentMonths, bool HasCollateral);
