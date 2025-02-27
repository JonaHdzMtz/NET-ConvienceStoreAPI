
using ConvinenceStore.Models.DTO;
using NameSpace.Models.DTO;

namespace ConvinenceStore.Business.Interface
{
    
    public interface ISale
    {
        public Task<int> createVenta(SaleDTO venta);
        public Task<List<SaleDTO>> getVentas();
        public Task<int> putVenta(SaleDataDTO venta);
    }
}