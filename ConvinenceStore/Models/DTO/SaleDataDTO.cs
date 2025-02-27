
using ConvinenceStore.Models.DTO;

namespace NameSpace.Models.DTO;
public class SaleDataDTO
{
    public SaleDTO Sale { get; set; }
    public List<ProductSaleDTO> Products { get; set; }
    
}