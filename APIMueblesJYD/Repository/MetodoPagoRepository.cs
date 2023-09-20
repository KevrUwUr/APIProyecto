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
    public class MetodoPagoRepository : RepositoryBase<MetodoPago>, IMetodoPagoRepository
    {
        public MetodoPagoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<MetodoPago> GetAllPaymentMethods(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.NombrePlataforma)
                .ToList();

        public MetodoPago GetPaymentMethod(Guid IdMetodoPago, bool trackChanges) =>
            FindByCondition(c => c.IdMetodoPago.Equals(IdMetodoPago), trackChanges)
            .SingleOrDefault();

        public void CreatePaymentMethod(MetodoPago metodoPago) => Create(metodoPago);
        public IEnumerable<MetodoPago> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.IdMetodoPago), trackChanges)
            .ToList();
        public void DeletePaymentMethod(MetodoPago metodoPago) => Delete(metodoPago);
    }
}
