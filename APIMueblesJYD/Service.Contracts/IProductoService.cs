﻿using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProductoService
    {
        IEnumerable<ProductoDTO> GetAllProducts(bool trackChanges);
        ProductoDTO GetProduct(Guid Id, bool trackChanges);
    }
}
