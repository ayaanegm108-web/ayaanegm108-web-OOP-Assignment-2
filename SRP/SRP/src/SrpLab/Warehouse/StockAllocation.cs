namespace SrpLab;

public sealed record StockAllocation(string Sku, int Allocated, int Needed)
{
    public bool IsShort => Allocated < Needed;
}
