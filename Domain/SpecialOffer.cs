namespace Domain;
public record SpecialOffer(string Sku, int Quantity, double OfferPrice) : IOffer
{
    public double CalculateDiscount(int itemCount)
    {
        throw new NotImplementedException();
    }
}