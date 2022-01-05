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
            new Item("A99", 0.50, new MultiBuyOffer("A99", 3, 1.30)),
            new Item("B15", 0.30, new MultiBuyOffer("B15", 2, 0.45)),
            new Item("C40", 0.60)
        };
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

    [TestCase("A99", 0.50)]
    [TestCase("B15", 0.30)]
    [TestCase("C40", 0.60)]
    public void ScanOneItem_TotalShouldBe_ItemPrice(string sku, double expectedTotal)
    {
        //arrange
        var sut = GetCheckout();

        //act
        sut.ScanItem(sku);

        var total = sut.GetTotalPrice();

        //assert
        Assert.AreEqual(total, expectedTotal);
    }

    [TestCase("A99,B15,C40", 1.40)]
    public void ScanMultipleItems_ShouldCalculate_CorrectTotalPrice(string skus, double expectedTotal)
    {
        //arrange
        var sut = GetCheckout();

        //act
        sut.ScanMultipleItems(skus);

        var total = sut.GetTotalPrice();

        //assert
        Assert.AreEqual(expectedTotal, total);
    }

    [TestCase("B15,A99,B15,C40", 1.55)]
    [TestCase("A99,A99,A99", 1.30)]
    [TestCase("B15,B15", 0.45)]
    [TestCase("B15,C40,B15,A99,B15", 1.85)]
    public void ScanMultipleItems_ProductQualifiesForOffer_ShouldApplyCorrectOffer(string skus, double expectedTotal)
    {
        //arrange
        var sut = GetCheckout();

        //act
        sut.ScanMultipleItems(skus);

        var total = sut.GetTotalPrice();

        //assert
        Assert.AreEqual(expectedTotal, total);
    }

    private Checkout GetCheckout() => new Checkout(_products);
}
