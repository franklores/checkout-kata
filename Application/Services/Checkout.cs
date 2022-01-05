namespace Application.Services;

using Application.Interfaces;

using Domain;

using System;
using System.Threading.Tasks;

public class Checkout : ICheckout
{
    public Task<decimal> GetTotalPrice()
    {
        throw new NotImplementedException();
    }

    public Task ScanItem(Item item)
    {
        throw new NotImplementedException();
    }
}