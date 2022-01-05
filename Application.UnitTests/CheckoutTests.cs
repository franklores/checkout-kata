namespace Application.UnitTests;

using Application.Services;

using NUnit.Framework;

public class CheckoutTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ScanNoItems_Total_ShouldBeZero()
    {
        //arrange
        var sut = new Checkout();

        //act
        var total = sut.GetTotalPrice();

        //assert
        Assert.AreEqual(0, total);
    }

    [TestCase("A99", 0.50)]
    [TestCase("B15", 0.30)]
    [TestCase("C40", 0.40)]
    public void ScanOneItem_TotalShouldBe_ItemPrice(string sku, decimal expectedTotal)
    {
        //arrange
        var sut = new Checkout();

        //act
        sut.ScanItem(sku);

        var total = sut.GetTotalPrice();

        //assert
        Assert.AreEqual(total, expectedTotal);
    }
}