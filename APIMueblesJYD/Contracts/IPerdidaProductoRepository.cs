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
        IEnumerable<PerdidaProducto> GetAllLoseProductsByLose(Guid perdidaId, bool trackChanges);
        IEnumerable<PerdidaProducto> GetAllLoseProductsByProduct(Guid productoId, bool trackChanges);
        PerdidaProducto GetLoseProductByLoseAndProduct(Guid perdidaId, Guid productoId, bool trackChanges);
        void CreateLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId, PerdidaProducto perdidaProducto);
        void DeleteLoseProduct(PerdidaProducto perdidaProducto);
    }
}
