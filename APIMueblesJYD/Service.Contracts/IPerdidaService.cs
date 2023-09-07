using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPerdidaService
    {
        IEnumerable<PerdidaDTO> GetAllLoses(bool trackChanges);
        PerdidaDTO GetLose(Guid Id, bool trackChanges);
        PerdidaDTO CreateLose(PerdidaForCreationDTO lose);
        IEnumerable<PerdidaDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<PerdidaDTO> perdidas, string ids) CreateLoseCollection
            (IEnumerable<PerdidaForCreationDTO> loseCollection);
        void DeleteLose(Guid loseId, bool trackChanges);
        void UpdateLose(Guid loseId, PerdidaForUpdateDTO loseForUpdate, bool trackChanges);
    }
}
