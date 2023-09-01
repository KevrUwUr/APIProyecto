﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProveedorRepository
    {
        IEnumerable<Proveedor> GetAllSuppliers(bool trackChanges);
        Proveedor GetSuplier(Guid suplierId, bool trackChanges);
    }
}
