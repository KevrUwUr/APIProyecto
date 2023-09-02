using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMetodoPagoRepository
    {
        IEnumerable<MetodoPagoDTO> GetAllPayMethods(bool trackChanges);
        MetodoPagoDTO GetPayMethod(Guid payMethodId, bool trackChanges);
    }
}
