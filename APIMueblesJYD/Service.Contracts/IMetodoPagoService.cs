using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMetodoPagoService
    {
        IEnumerable<MetodoPagoDTO> GetAllPaymentMethods(bool trackChanges);
        MetodoPagoDTO GetPaymentMethod(int Id, bool trackChanges);
    }
}
