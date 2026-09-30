namespace SrpLab;

/// <summary>
/// Reason to change: finance changes the VAT rate or the format of the invoice line.
/// </summary>
public sealed class TuitionInvoiceLineWriter
{
    private const decimal VatRate = 0.14m;

    public string Write(string courseCode, decimal tuition, bool isSeated)
    {
        if (!isSeated) return $"{courseCode},WAITLIST,0.00";
        var vat = Math.Round(tuition * VatRate, 2);
        return $"{courseCode},TUITION,{tuition:0.00},VAT,{vat:0.00},TOTAL,{(tuition + vat):0.00}";
    }
}
