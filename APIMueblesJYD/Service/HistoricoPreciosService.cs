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
    internal sealed class HistoricoPreciosService : IHistoricoPreciosRepository
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public HistoricoPreciosService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<HistoricoPreciosDTO> GetAllPriceHistories(bool trackChanges)
        {
            var historicoPrecios = _repository.HistoricoPrecios.GetAllPriceHistories(trackChanges);
            var historicoPreciosDTO = _mapper.Map<IEnumerable<HistoricoPreciosDTO>>(historicoPrecios);

            return historicoPreciosDTO;
        }

        public HistoricoPreciosDTO GetPriceHistory(int Id, bool trackChanges)
        {
            var historicoPrecios = _repository.HistoricoPrecios.GetPriceHistory(Id, trackChanges);
            if(historicoPrecios == null)
            {
                throw new HistoricoPreciosNotFoundException(Id);
            }

            var historicoPreciosDTO = _mapper.Map<HistoricoPreciosDTO>(historicoPrecios);
            return historicoPreciosDTO;
        }
    }
}
