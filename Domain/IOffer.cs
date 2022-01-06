namespace Domain;

public interface IOffer
{
    double OfferPrice { get; }

    int Quantity { get; }

    string Sku { get; }

    double CalculateDiscount(int itemCount, double unitPrice) => 0;
}