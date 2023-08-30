using Contracts;
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
    internal sealed class CargoService : ICargoService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CargoService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Cargo> GetAllCargos(bool trackChanges)
        {
            try
            {
                var companies = _repository.Cargo.GetAllCargos(trackChanges);
                var cargosDto = companies.Select(c => 
                new CargoDto(c.Id, c.Name ?? "", string.Join(' ',c.Address, c.Country))).ToList();
                return cargosDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the { nameof(GetAllCargos)}service method { ex}");
            throw;
            }

        }
    }
}
