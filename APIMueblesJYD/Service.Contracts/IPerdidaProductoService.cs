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
        PerdidaProductoDTO GetLoseProduct(Guid Id, bool trackChanges);


        PerdidaProductoDTO GetLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId, bool trackChanges);


        IEnumerable<PerdidaProductoDTO> GetLoseProductsByLose(Guid perdidaId, bool trackChanges);
        PerdidaProductoDTO GetLoseProductByLose(Guid perdidaId, Guid Id, bool trackChanges);
        PerdidaProductoDTO CreateLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId, PerdidaProductoForCreationDTO perdidaProductoForCreation, bool trackChanges);
        void DeleteLoseProductForLose(Guid perdidaId, Guid productoId, Guid Id, bool trackChanges);
        void UpdateLoseProductForLoseAndProduct(Guid perdidaId, Guid productoId, Guid id,
            PerdidaProductoForUpdateDTO perdidaProductoForUpdate, bool perdProdTrackChanges, bool perdTrackChanges, bool prodTrackChanges);

        IEnumerable<PerdidaProductoDTO> GetLoseProductsByProduct(Guid productoId, bool trackChanges);
        PerdidaProductoDTO GetLoseProductByProduct(Guid productoId, Guid Id, bool trackChanges);
    }
}
