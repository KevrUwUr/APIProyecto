using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProveedorRepository : RepositoryBase<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Proveedor> GetAllSuppliers(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.RazonSocial)
                .ToList();

        public Proveedor GetSupplier(Guid IdProveedor, bool trackChanges) =>
            FindByCondition(c => c.IdProveedor.Equals(IdProveedor), trackChanges)
            .SingleOrDefault();

    }
}
