using Contracts;
using Entities.Models;
using Repository.Configuration;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DetalleFacturaCompraRepository : RepositoryBase<DFacturaCompraDTO>, IDetFacturaCompraRepository
    {
        public DetalleFacturaCompraRepository (RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<DFacturaCompraDTO> GetAllDetBuyBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.FacturaCompraId)
                .ToList();

        public DFacturaCompraDTO GetDetBuyBill(Guid FacturaCompraId, bool trackChanges) =>
            FindByCondition(c => c.FacturaCompraId.Equals(FacturaCompraId), trackChanges)
            .SingleOrDefault();
    
    }
}
