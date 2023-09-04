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
    internal sealed class PerdidaService : IPerdidaRepository
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PerdidaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<PerdidaDTO> GetAllLoses(bool trackChanges)
        {
            var perdida = _repository.Perdida.GetAllLoses(trackChanges);
            var perdidaDTO = _mapper.Map<IEnumerable<PerdidaDTO>>(perdida);

            return perdidaDTO;
        }

        public PerdidaDTO GetLose(int lostId, bool trackChanges)
        {
            var perdida = _repository.Perdida.GetLose(lostId, trackChanges);
            if (perdida == null)
            {
                throw new PerdidaNotFoundException(lostId);
            }

            var perdidaDTO = _mapper.Map<PerdidaDTO>(perdida);
            return perdidaDTO;
        }
    }
}
