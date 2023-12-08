using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FacturaVentaRepository : RepositoryBase<FacturaVenta>, IFacturaVentaRepository
    {
        public FacturaVentaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<FacturaVenta> GetAllSaleBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.FacturaVentaId)
                .ToList();

        public FacturaVenta GetSaleBill(Guid FacturaVentaId, bool trackChanges) =>
            FindByCondition(c => c.FacturaVentaId.Equals(FacturaVentaId), trackChanges)
            .SingleOrDefault();

        public IEnumerable<FacturaVenta> GetAllSaleBillsForUser(Guid usuarioId, bool trackChanges) =>
            FindByCondition(e => e.IdUsuario.Equals(usuarioId), trackChanges)
            .OrderBy(e => e.Usuarios)
            .ToList();

        public FacturaVenta GetSaleBillForUser(Guid usuarioId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.IdUsuario.Equals(usuarioId) && e.FacturaVentaId == (Id), trackChanges)
            .SingleOrDefault();

        public void CreateSaleBillForUser(Guid usuarioId, FacturaVenta facVenta)
        {
            facVenta.IdUsuario = usuarioId;
            Create(facVenta);
        }

        public void DeleteSaleBill(FacturaVenta facVenta) => Delete(facVenta);
    }
}
