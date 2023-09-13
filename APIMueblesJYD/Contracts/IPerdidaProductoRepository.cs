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
        IEnumerable<PerdidaProducto> GetAllLoseProductsByLose(Guid perdidaId, bool trackChanges);
        //PerdidaProducto GetLoseProductByLose(Guid perdidaId, Guid Id, bool trackChanges);


        IEnumerable<PerdidaProducto> GetAllLoseProductsByLoseAndProduct(Guid perdidaId, Guid productoId, bool trackChanges);
        PerdidaProducto GetLoseProductByLoseAndProduct(Guid perdidaId, Guid productoId, bool trackChanges);


        void CreateLoseProductForLoseProduct(Guid perdidaId, Guid productoId, PerdidaProducto perdidaProducto);
        void DeleteLoseProduct(PerdidaProducto perdidaProducto);

        IEnumerable<PerdidaProducto> GetAllLoseProductsByProduct(Guid productoId, bool trackChanges);
        //PerdidaProducto GetLoseProductByProduct(Guid productoId, Guid Id, bool trackChanges);
    }
}
