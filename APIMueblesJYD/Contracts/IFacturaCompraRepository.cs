﻿using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFacturaCompraRepository
    {
        IEnumerable<FacturaCompra> GetAllBuyBills(bool trackChanges);
        FacturaCompra GetBuyBill(Guid buyBillId, bool trackChanges);
    }
}
