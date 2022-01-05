namespace Application.UnitTests;

using Application.Services;

using Domain;

using NUnit.Framework;

using System.Collections.Generic;

public class CheckoutTests
{
    private readonly List<Item> _products;

    public CheckoutTests()
    {
        _products = new List<Item>
        {
            new Item("A99", 0.50, new SpecialOffer("A99",3,1.30)),
            new Item("B15", 0.30, new SpecialOffer("B15", 2, 0.45)),
            new Item("C40", 0.60)
        };
    }

    [Test]
    public void ScanNoItems_Total_ShouldBeZero()
    {
        //arrange
        var sut = GetCheckout();

        //act
        var total = sut.GetTotalPrice();

        //assert
        Assert.AreEqual(0, total);
    }

    private Checkout GetCheckout() => new Checkout(_products);

    [TestCase("A99", 0.50)]
    [TestCase("B15", 0.30)]
    [TestCase("C40", 0.60)]
    public void ScanOneItem_TotalShouldBe_ItemPrice(string sku, decimal expectedTotal)
    {
        //arrange
        var sut = GetCheckout();

        //act
        sut.ScanItem(sku);

        var total = sut.GetTotalPrice();

        //assert
        Assert.AreEqual(total, expectedTotal);
    }

    [Test]
    public void ScanInvalidItem_TotalShouldBeZero()
    {
        //arrange
        var sut = GetCheckout();

        //act
        sut.ScanItem("InvalidSku");
        var total = sut.GetTotalPrice();

        //assert
        Assert.AreEqual(0, total);
    }
}