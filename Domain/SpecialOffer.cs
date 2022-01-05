﻿namespace Domain;
public record SpecialOffer(string Sku, int Quantity, double OfferPrice) : IOffer
{
    public double CalculateDiscount(int itemCount, double unitPrice)
    {
        var discount = (Quantity * unitPrice) - OfferPrice;

        var totalDiscount = itemCount / Quantity * discount;

        return totalDiscount;
    }
}