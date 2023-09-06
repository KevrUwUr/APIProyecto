using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class ProveedorService : IProveedorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProveedorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ProveedorDTO> GetAllSuppliers(bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetAllSuppliers(trackChanges);
            var proveedorDTO = _mapper.Map<IEnumerable<ProveedorDTO>>(proveedor);

            return proveedorDTO;
        }

        public ProveedorDTO GetSupplier(Guid Id, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(Id, trackChanges);
            if (proveedor == null)
            {
                throw new ProveedorNotFoundException(Id);
            }

            var proveedorDTO = _mapper.Map<ProveedorDTO>(proveedor);
            return proveedorDTO;
        }
    }
}
