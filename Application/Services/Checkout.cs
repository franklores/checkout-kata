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
        if (!_bag.Any())
            return 0;

        var total = _bag.Sum(x => x.UnitPrice).Round();

        foreach (var product in _bag.Distinct())
        {
            if (!QualifiesForDiscount(product))
                continue;

            total -= product.Offer!.CalculateDiscount(_bag.Count(x => x.Sku == product.Sku));
        }

        return total;
    }

    private bool QualifiesForDiscount(Item product)
    {
        if (product.Offer is null)
            return false;

        var productCount = _bag.Count(x => x.Sku == product.Sku);

        return productCount >= product.Offer.Quantity;
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