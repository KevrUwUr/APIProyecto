using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFacturaVentaService
    {
        IEnumerable<FacturaVentaDTO> GetAllSaleBills(bool trackChanges);
        FacturaVentaDTO GetSaleBill(Guid Id, bool trackChanges);
        IEnumerable<FacturaVentaDTO> GetAllSaleBillsForUser(Guid usuarioId, bool trackChanges);
        FacturaVentaDTO GetSaleBillForUser(Guid usuarioId, Guid Id, bool trackChanges);
        FacturaVentaDTO CreateSaleBillForUser(Guid usuarioId, FacturaVentaForCreationDTO facVentaForCreation, bool trackChanges);
        void DeleteSaleBillForUser(Guid usuarioId, Guid Id, bool trackChanges);
        void UpdateSaleBillForUser(Guid usuarioId, Guid id,
            FacturaVentaForUpdateDTO facVentaForUpdate, bool usuarioTrackChanges, bool facVentaTrackChanges);
        (FacturaVentaForUpdateDTO facVentaToPatch, FacturaVenta facVentaEntity) GetFacturaVentaForPatch
            (Guid usuarioId, Guid id, bool usuarioTrackChanges, bool facVentaTrackChanges);
        void SaveChangesForPatch(FacturaVentaForUpdateDTO facVentaToPatch, FacturaVenta facVentaEntity);
    }
}
