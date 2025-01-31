
using ConvinenceStore.Models.DTO;

namespace ConvinenceStore.Business.Interface;

public interface IProduct{

    public Task<List<ProductDTO>> getProductsAsync();
    public Task<int> createProduct(ProductDTO product); 
}