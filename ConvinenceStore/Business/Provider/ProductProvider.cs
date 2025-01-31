
using ConvinenceStore.Business.Interface;
using ConvinenceStore.Models;
using ConvinenceStore.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ConvinenceStore.Business.Provider;

public class ProductProvider : IProduct
{

    private readonly ConvinenceStoreContext _connection;
    public ProductProvider(ConvinenceStoreContext connection)
    {
        _connection = connection;
    }

    public async Task<int> createProduct(ProductDTO product)
    {
        await _connection.Products.AddAsync(new Product()
        {
            Price = product.Price,
            ProductDescription = product.ProductDescription,
            ProductName = product.ProductName,
            Stock = product.Stock
        });
        var changes = await _connection.SaveChangesAsync();
        if (changes == 1)
            return 200;
        return 400;
    }

    public async Task<List<ProductDTO>> getProductsAsync()
    {
        try
        {
            List<ProductDTO> productList = new List<ProductDTO>();
            var result = await _connection.Products.ToListAsync();
            if (result != null)
            {
                foreach (var item in result)
                {
                    ProductDTO itemDTO = new ProductDTO
                    {
                        IdProduct = item.IdProduct,
                        Price = item.Price,
                        ProductDescription = item.ProductDescription,
                        ProductName = item.ProductName,
                        Stock = item.Stock
                    };
                    productList.Add(itemDTO);

                }
            }
            return productList;
        }
        catch (Exception e)
        {
            throw new Exception("error en servidor", e);
        }
    }
}