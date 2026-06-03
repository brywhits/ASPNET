using System;
using System.Collections.Generic;
using Testing.Models;

namespace Testing;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts(); //stubbed out method
    public Product GetProduct(int id);
}