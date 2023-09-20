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
    internal sealed class PerdidaService : IPerdidaService
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

        public PerdidaDTO GetLose(Guid Id, bool trackChanges)
        {
            var perdida = _repository.Perdida.GetLose(Id, trackChanges);
            if (perdida == null)
            {
                throw new PerdidaNotFoundException(Id);
            }

            var perdidaDTO = _mapper.Map<PerdidaDTO>(perdida);
            return perdidaDTO;
        }
        public PerdidaDTO CreateLose(PerdidaForCreationDTO lose)
        {
            var perdidaEntity = _mapper.Map<Perdida>(lose);

            _repository.Perdida.CreateLose(perdidaEntity);
            _repository.Save();

            var loseToReturn = _mapper.Map<PerdidaDTO>(perdidaEntity);
            return loseToReturn;
        }
        public IEnumerable<PerdidaDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            var loseEntities = _repository.Perdida.GetByIds(ids, trackChanges);
            if (ids.Count() != loseEntities.Count())
                throw new CollectionByIdsBadRequestException();
            var companiesToReturn = _mapper.Map<IEnumerable<PerdidaDTO>>(loseEntities);

            return companiesToReturn;
        }
        public (IEnumerable<PerdidaDTO> perdidas, string ids) CreateLoseCollection
            (IEnumerable<PerdidaForCreationDTO> loseCollection)
        {
            if (loseCollection is null)
                throw new PerdidaCollectionBadRequest();
            var loseEntities = _mapper.Map<IEnumerable<Perdida>>(loseCollection);
            foreach (var lose in loseEntities)
            {
                _repository.Perdida.CreateLose(lose);
            }
            _repository.Save();
            var loseCollectionToReturn =
            _mapper.Map<IEnumerable<PerdidaDTO>>(loseEntities);
            var ids = string.Join(",", loseCollectionToReturn.Select(c => c.IdPerdida));
            return (loses: loseCollectionToReturn, ids: ids);
        }
        public void DeleteLose(Guid loseId, bool trackChanges)
        {
            var lose = _repository.Perdida.GetLose(loseId, trackChanges);
            if (lose == null)
                throw new PerdidaNotFoundException(loseId);

            _repository.Perdida.DeleteLose(lose);
            _repository.Save();
        }
        public void UpdateLose(Guid loseId, PerdidaForUpdateDTO loseForUpdate, bool trackChanges)
        {
            var loseEntity = _repository.Perdida.GetLose(loseId, trackChanges);
            if (loseEntity == null)
                throw new PerdidaNotFoundException(loseId);

            _mapper.Map(loseForUpdate, loseEntity);
            _repository.Save();
        }
    }
}
