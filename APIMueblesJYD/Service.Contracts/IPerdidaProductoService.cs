using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPerdidaProductoService
    {
        IEnumerable<PerdidaProductoDTO> GetAllLoseProducts(bool trackChanges);
        
        IEnumerable<PerdidaProductoDTO> GetAllLoseProductsForLoseAndProduct(Guid perdidaId, Guid productoId, bool trackChanges);
        PerdidaProductoDTO GetLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId, bool trackChanges);

        IEnumerable<PerdidaProductoDTO> GetAllLoseProductsByLose(Guid perdidaId, bool trackChanges);
        IEnumerable<PerdidaProductoDTO> GetAllLoseProductsByProduct(Guid productoId, bool trackChanges);

        PerdidaProductoDTO CreateLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId, PerdidaProductoForCreationDTO perdidaProductoForCreation, bool trackChanges);
        void DeleteLoseProductForLose(Guid perdidaId, Guid productoId, bool trackChanges);
        void UpdateLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId,
            PerdidaProductoForUpdateDTO perdidaProductoForUpdate, bool perdProdTrackChanges, bool perdTrackChanges, bool prodTrackChanges);
    }
}
