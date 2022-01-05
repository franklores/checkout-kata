﻿namespace Application.Interfaces;

public interface ICheckout
{
    void ScanItem(string sku);

    decimal GetTotalPrice();
}