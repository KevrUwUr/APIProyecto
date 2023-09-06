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
        IEnumerable<MetodoPagoDTO> GetAllPaymentMethods(bool trackChanges);
        MetodoPagoDTO GetPaymentMethod(Guid payMethodId, bool trackChanges);
    }
}
