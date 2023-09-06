using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MetodoPagoRepository : RepositoryBase<MetodoPagoDTO>, IMetodoPagoRepository
    {
        public MetodoPagoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<MetodoPagoDTO> GetAllPaymentMethods(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NombrePlataforma)
                .ToList();

        public MetodoPagoDTO GetPaymentMethod(Guid IdMetodoPago, bool trackChanges) =>
            FindByCondition(c => c.IdMetodoPago.Equals(IdMetodoPago), trackChanges)
            .SingleOrDefault();

    }
}
