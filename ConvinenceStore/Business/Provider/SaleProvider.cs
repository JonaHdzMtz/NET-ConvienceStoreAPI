
namespace ConvinenceStore.Business.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ConvinenceStore.Business.Interface;
    using ConvinenceStore.Models;
    using ConvinenceStore.Models.DTO;
    using Microsoft.EntityFrameworkCore;
    using NameSpace.Models.DTO;

    public class SaleProvider : ISale
    {
        private readonly ConvinenceStoreContext _context;

        public SaleProvider(ConvinenceStoreContext context)
        {
            _context = context;
        }

        public async Task<int> createVenta(SaleDTO venta)
        {
            try
            {
                Sale sale = new Sale
                {
                    SaleDate = venta.SaleDate,
                    SaleTotal = venta.SaleTotal,
                    IdUser = venta.IdUser
                };

                _context.Sales.Add(sale);
                int changes = await _context.SaveChangesAsync();

                return changes;
            }
            catch (Exception e)
            {
                return 500;
            }
        }

        public async Task<List<SaleDTO>> getVentas()
        {
            List<SaleDTO> sales = await _context.Sales.Select(s => new SaleDTO
            {
                IdSale = s.IdSale,
                SaleDate = s.SaleDate,
                SaleTotal = s.SaleTotal,
                IdUser = s.IdUser
            }).ToListAsync();

            return sales;
        }

        public async Task<int> putVenta(SaleDataDTO venta)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            var changesSale = 0;
            var changesProduct = 0;
            Sale sale = new Sale
            {
                SaleDate = venta.Sale.SaleDate,
                SaleTotal = venta.Sale.SaleTotal,
                IdUser = venta.Sale.IdUser
            };
            await _context.Sales.AddAsync(sale);
                changesSale = await _context.SaveChangesAsync();
            var products = venta.Products.Select(p => new ProductSale
            {
                IdProduct = p.IdProduct,
                IdSale = sale.IdSale,
                UnitPrice = p.UnitPrice,
                Amount = p.Amount,
                Subtotal = p.Subtotal
            }).ToList();
            try
            {
                
                await _context.ProductSales.AddRangeAsync(products);
                changesProduct = await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return 200;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return 500;
            }

        }
    }
}