using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MetodoPagoRepository : RepositoryBase<MetodoPago>, IMetodoPagoRepository
    {
        public MetodoPagoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<MetodoPago> GetAllPayMethods(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NombrePlataforma)
                .ToList();

        public MetodoPago GetPayMethod(Guid IdMetodoPago, bool trackChanges) =>
            FindByCondition(c => c.IdMetodoPago.Equals(IdMetodoPago), trackChanges)
            .SingleOrDefault();

    }
}
