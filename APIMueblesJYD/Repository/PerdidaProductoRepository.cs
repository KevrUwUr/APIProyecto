using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PerdidaProductoRepository : RepositoryBase<PerdidaProducto>, IPerdidaProductoRepository
    {
        public PerdidaProductoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<PerdidaProducto> GetAllProductLoses(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.IdPerdida)
                .ToList();

        public PerdidaProducto GetProductLose(Guid IdPerdidaProducto, bool trackChanges) =>
            FindByCondition(c => c.IdPerdida.Equals(IdPerdidaProducto), trackChanges)
            .SingleOrDefault();

        public IEnumerable<PerdidaProducto> GetAllLoseProductsByLose(Guid perdidaId, bool trackChanges) =>
            FindByCondition(e => e.IdPerdida.Equals(perdidaId), trackChanges)
            .OrderBy(e => e.Perdida)
            .ToList();
        //public PerdidaProducto GetLoseProductByLose(Guid perdidaId, Guid Id, bool trackChanges) =>
        //    FindByCondition(e => e.IdPerdida.Equals(perdidaId) && e.PerdidaProductoId == (Id), trackChanges)
        //    .SingleOrDefault();


        public IEnumerable<PerdidaProducto> GetAllLoseProductsByLoseAndProduct(Guid perdidaId, Guid productoId, bool trackChanges) =>
            FindByCondition(e => e.IdPerdida.Equals(perdidaId) && e.ProductoId==(productoId), trackChanges)
            .OrderBy(e => e.Perdida)
            .ToList();
        public PerdidaProducto GetLoseProductByLoseAndProduct(Guid perdidaId, Guid productoId, bool trackChanges) =>
            FindByCondition(e => e.IdPerdida.Equals(perdidaId) && e.ProductoId == (productoId), trackChanges)
            .SingleOrDefault();


        public void CreateLoseProductForLoseProduct(Guid perdidaId, Guid productoId, PerdidaProducto perdidaProducto)
        {
            perdidaProducto.IdPerdida = perdidaId;
            perdidaProducto.ProductoId = productoId;
            Create(perdidaProducto);
        }

        public void DeleteLoseProduct(PerdidaProducto perdidaProducto) => Delete(perdidaProducto);

        public IEnumerable<PerdidaProducto> GetAllLoseProductsByProduct(Guid productoId, bool trackChanges) =>
            FindByCondition(e => e.ProductoId.Equals(productoId), trackChanges)
            .OrderBy(e => e.Perdida)
            .ToList();
        //public PerdidaProducto GetLoseProductByProduct(Guid productoId, Guid Id, bool trackChanges) =>
        //    FindByCondition(e => e.ProductoId.Equals(productoId) && e.PerdidaProductoId == (Id), trackChanges)
        //    .SingleOrDefault();
    }
}
