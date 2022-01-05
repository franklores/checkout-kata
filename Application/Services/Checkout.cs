namespace Application.Services;

using Application.Interfaces;

using Domain;

public class Checkout : ICheckout
{
    private readonly List<Item> _bag = new List<Item>();

    private readonly IEnumerable<Item> _products;

    public Checkout(IEnumerable<Item> products)
    {
        _products = products;
    }

    public double GetTotalPrice()
    {
        return _bag.Sum(x => x.UnitPrice);
    }

    public void ScanItem(string sku)
    {
        var item = _products.FirstOrDefault(x => x.Sku == sku);

        if (item != null)
        {
            _bag.Add(item);
        }
    }
}