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
        return _conn.Query<Product>("SELECT * FROM Products;");
    }
    public Product GetProduct(int id)//implementation
    {
        return _conn.QuerySingle<Product>("SELECT * FROM Products WHERE PRODUCTID = @id", new { id = id });
    }
    public void UpdateProduct(Product product)
    {
        _conn.Execute("UPDATE Products SET Name = @name, Price = @price WHERE ProductID = @id",
            new {name = product.Name, price = product.Price, id = product.ProductID });
    }
} 