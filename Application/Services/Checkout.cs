namespace Application.Services;

using Application.Interfaces;

using Domain;

using System;

public class Checkout : ICheckout
{
    private readonly IEnumerable<Item> _bag = new List<Item>();

    public decimal GetTotalPrice()
    {
        throw new NotImplementedException();
    }

    public void ScanItem(string sku)
    {
        throw new NotImplementedException();
    }
}