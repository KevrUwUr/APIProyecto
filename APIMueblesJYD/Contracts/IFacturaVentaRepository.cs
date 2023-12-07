using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFacturaVentaRepository
    {
        IEnumerable<FacturaVenta> GetAllSaleBills(bool trackChanges);
        FacturaVenta GetSaleBill(Guid saleBillId, bool trackChanges);
        IEnumerable<FacturaVenta> GetAllSaleBillsForUser(Guid usuarioId, bool trackChanges);
        FacturaVenta GetSaleBillForUser(Guid usuarioId, Guid Id, bool trackChanges);
        void CreateSaleBillForUser(Guid usuarioId, FacturaVenta facVenta);
        void DeleteSaleBill(FacturaVenta facVenta);
    }
}
