namespace Application.Services;

public static class Extensions
{
    public static double Round(this double value) => Math.Round(value, 2, MidpointRounding.AwayFromZero);

    public static void ScanMultipleItems(this Checkout checkout, string skus)
    {
        foreach (var sku in skus.Split(",", StringSplitOptions.RemoveEmptyEntries))
        {
            checkout.ScanItem(sku);
        }
    }
}