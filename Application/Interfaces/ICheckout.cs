namespace Application.Interfaces;

public interface ICheckout
{
    void ScanItem(string sku);

    double GetTotalPrice();
}