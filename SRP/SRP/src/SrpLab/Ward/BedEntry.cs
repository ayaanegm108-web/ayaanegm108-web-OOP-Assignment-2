namespace SrpLab;

/// <summary>One occupied bed: which patient is in it and their acuity score.</summary>
public sealed record BedEntry(int Bed, string PatientId, int Acuity);
