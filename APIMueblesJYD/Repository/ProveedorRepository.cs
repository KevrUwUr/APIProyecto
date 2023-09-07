﻿using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProveedorRepository : RepositoryBase<ProveedorDTO>, IProveedorRepository
    {
        public ProveedorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<ProveedorDTO> GetAllSuppliers(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.RazonSocial)
                .ToList();

        public ProveedorDTO GetSupplier(Guid IdProveedor, bool trackChanges) =>
            FindByCondition(c => c.IdProveedor.Equals(IdProveedor), trackChanges)
            .SingleOrDefault();

        public void CreateSupplier(Proveedor supplier) => Create(supplier);
        public IEnumerable<Proveedor> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.IdProveedor), trackChanges)
            .ToList();
        public void DeleteSupplier(Proveedor supplier) => Delete(supplier);
    }
}
