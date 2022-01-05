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
}