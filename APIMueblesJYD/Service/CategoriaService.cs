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
    internal sealed class CategoriaService : ICategoriaService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CategoriaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<CategoriaDTO> GetAllCategories(bool trackChanges)
        {
            var categories = _repository.Categoria.GetAllCategories(trackChanges);
            var categoriesDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categories);

            return categoriesDto;
        }

        public CategoriaDTO GetCategory(int Id, bool trackChanges)
        {
            var category = _repository.Categoria.GetCategory(Id, trackChanges);
            if(category == null)
            {
                throw new CategoriaNotFoundException(Id);
            }

            var categoryDto = _mapper.Map<CategoriaDTO>(category);
            return categoryDto;
        }
    }
}
