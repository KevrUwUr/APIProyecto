using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPerdidaRepository
    {
        IEnumerable<Perdida> GetAllLosts(bool trackChanges);
        Perdida GetLost(Guid lostId, bool trackChanges);
    }
}
