using System.Collections.Generic;
using System.Data;
using Dapper;
using Testing.Models;

namespace Testing;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _conn;

    public ProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }
    
    /* Now that the repo has been called, Repo queries SQL for data -
     and returns Product objects and stores them in products in -
     Index method in Product Controller */
    public IEnumerable<Product> GetAllProducts()//implements stubbed out method
    {
        return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
    }

    public Product GetProduct(int id)//implementation
    {
        return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
    }
} 