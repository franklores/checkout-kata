namespace Application.Interfaces;

using Domain;

using System.Threading.Tasks;

public interface ICheckout
{
    Task ScanItem(Item item);

    Task<decimal> GetTotalPrice();
}
