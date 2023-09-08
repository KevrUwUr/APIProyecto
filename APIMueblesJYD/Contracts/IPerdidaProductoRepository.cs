using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPerdidaProductoRepository
    {
        IEnumerable<PerdidaProducto> GetAllProductLoses(bool trackChanges);
        PerdidaProducto GetProductLose(Guid IdPerdidaProducto, bool trackChanges);
        IEnumerable<PerdidaProducto> GetLoseProductsByLose(Guid perdidaId, bool trackChanges);
        PerdidaProducto GetLoseProductByLose(Guid perdidaId, Guid Id, bool trackChanges);
        void CreateLoseProductForLoseProduct(Guid perdidaId, Guid productoId, PerdidaProducto perdidaProducto);
        void DeleteLoseProduct(PerdidaProducto perdidaProducto);

        IEnumerable<PerdidaProducto> GetLoseProductsByProduct(Guid productoId, bool trackChanges);
        PerdidaProducto GetLoseProductByProduct(Guid productoId, Guid Id, bool trackChanges);
    }
}
