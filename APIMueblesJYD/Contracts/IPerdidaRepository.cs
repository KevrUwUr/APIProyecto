using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPerdidaRepository
    {
        IEnumerable<PerdidaDTO> GetAllLoses(bool trackChanges);
        PerdidaDTO GetLose(int lostId, bool trackChanges);
    }
}
