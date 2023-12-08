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
    internal sealed class HistoricoPreciosService : IHistoricoPreciosService
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

        public HistoricoPreciosDTO GetPriceHistory(Guid Id, bool trackChanges)
        {
            var historicoPrecios = _repository.HistoricoPrecios.GetPriceHistory(Id, trackChanges);
            if(historicoPrecios == null)
            {
                throw new HistoricoPreciosNotFoundException(Id);
            }

            var historicoPreciosDTO = _mapper.Map<HistoricoPreciosDTO>(historicoPrecios);
            return historicoPreciosDTO;
        }

        public IEnumerable<HistoricoPreciosDTO> GetAllPriceHistoriesForProduct(Guid productoId, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);

            if (producto is null)
            {
                throw new HistoricoPreciosNotFoundException(productoId);
            }
            var histPreciosFromDb = _repository.HistoricoPrecios.GetAllPriceHistoriesForProduct(productoId, trackChanges);
            var histPreciosDTO = _mapper.Map<IEnumerable<HistoricoPreciosDTO>>(histPreciosFromDb);

            return histPreciosDTO;
        }

        public HistoricoPreciosDTO GetPriceHistoryForProduct(Guid productoId, Guid Id, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }
            var histPreciosDb = _repository.HistoricoPrecios.GetPriceHistoryForProduct(productoId, Id, trackChanges);
            if (histPreciosDb is null)
            {
                throw new HistoricoPreciosNotFoundException(Id);
            }
            var histPrecios = _mapper.Map<HistoricoPreciosDTO>(histPreciosDb);
            return histPrecios;
        }

        public HistoricoPreciosDTO CreatePriceHistoryForProduct(Guid productoId, HistoricoPreciosForCreationDTO priceHistory, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var historicoPrecioEntity = _mapper.Map<HistoricoPrecios>(priceHistory);

            _repository.HistoricoPrecios.CreatePriceHistoryForProduct(productoId, historicoPrecioEntity);
            _repository.Save();

            var priceHistoryToReturn = _mapper.Map<HistoricoPreciosDTO>(historicoPrecioEntity);
            return priceHistoryToReturn;
        }

        public void DeletePriceHistoryForProduct(Guid productoId, Guid priceHistoryId, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var priceHistory = _repository.HistoricoPrecios.GetPriceHistoryForProduct(productoId, priceHistoryId,
                trackChanges);
            if (priceHistory == null)
                throw new HistoricoPreciosNotFoundException(priceHistoryId);

            _repository.HistoricoPrecios.DeletePriceHistory(priceHistory);
            _repository.Save();
        }

        public void UpdatePriceHistoryForProduct(Guid productoId, Guid priceHistoryId, HistoricoPreciosForUpdateDTO priceHistoryForUpdate, bool productoTrackChanges, bool histPreciosTrackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, productoTrackChanges);
            if (producto is null)
            {
                throw new ProductoNotFoundException(priceHistoryId);
            }

            var priceHistoryEntity = _repository.HistoricoPrecios.GetPriceHistoryForProduct(productoId, priceHistoryId, histPreciosTrackChanges);
            if (priceHistoryEntity is null)
            {
                throw new HistoricoPreciosNotFoundException(priceHistoryId);
            }

            _mapper.Map(priceHistoryForUpdate, priceHistoryEntity);
            _repository.Save();
        }

        public (HistoricoPreciosForUpdateDTO histPreciosToPatch, HistoricoPrecios histPreciosEntity) GetHistoricoPreciosForPatch(Guid productoId, Guid id, bool productoTrackChanges, bool historicoPrecioTrackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, productoTrackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var historicoPrecioEntity = _repository.HistoricoPrecios.GetPriceHistoryForProduct(productoId, id, historicoPrecioTrackChanges);

            if (historicoPrecioEntity is null)
                throw new HistoricoPreciosNotFoundException(productoId);

            var historicoPrecioToPatch = _mapper.Map<HistoricoPreciosForUpdateDTO>(historicoPrecioEntity);
            return (historicoPrecioToPatch, historicoPrecioEntity);
        }

        public void SaveChangesForPatch(HistoricoPreciosForUpdateDTO historicoPrecioToPatch, HistoricoPrecios historicoPrecioEntity)
        {
            _mapper.Map(historicoPrecioToPatch, historicoPrecioEntity);
            _repository.Save();
        }
    }
}
