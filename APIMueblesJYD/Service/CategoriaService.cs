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
            var categoriesDTO = _mapper.Map<IEnumerable<CategoriaDTO>>(categories);

            return categoriesDTO;
        }


        public CategoriaDTO GetCategory(Guid Id, bool trackChanges)
        {
            var category = _repository.Categoria.GetCategory(Id, trackChanges);
            if(category == null)
            {
                throw new CategoriaNotFoundException(Id);
            }

            var categoryDTO = _mapper.Map<CategoriaDTO>(category);
            return categoryDTO;
        }
        public CategoriaDTO CreateCategory(CategoriaForCreationDTO category)
        {
            var categoriaEntity = _mapper.Map<Categoria>(category);

            _repository.Categoria.CreateCategory(categoriaEntity);
            _repository.Save();

            var categoryToReturn = _mapper.Map<CategoriaDTO>(categoriaEntity);
            return categoryToReturn;
        }
        public IEnumerable<CategoriaDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            var categoryEntities = _repository.Categoria.GetByIds(ids, trackChanges);
            if (ids.Count() != categoryEntities.Count())
                throw new CollectionByIdsBadRequestException();
            var companiesToReturn = _mapper.Map<IEnumerable<CategoriaDTO>>(categoryEntities);

            return companiesToReturn;
        }
        public (IEnumerable<CategoriaDTO> categorias, string ids) CreateCategoryCollection
            (IEnumerable<CategoriaForCreationDTO> categoryCollection)
        {
            if (categoryCollection is null)
                throw new CategoriaCollectionBadRequest();
            var categoryEntities = _mapper.Map<IEnumerable<Categoria>>(categoryCollection);
            foreach (var category in categoryEntities)
            {
                _repository.Categoria.CreateCategory(category);
            }
            _repository.Save();
            var categoryCollectionToReturn =
            _mapper.Map<IEnumerable<CategoriaDTO>>(categoryEntities);
            var ids = string.Join(",", categoryCollectionToReturn.Select(c => c.Id));
            return (categories: categoryCollectionToReturn, ids: ids);
        }
        public void DeleteCategory(Guid categoryId, bool trackChanges)
        {
            var category = _repository.Categoria.GetCategory(categoryId, trackChanges);
            if (category == null)
                throw new CategoriaNotFoundException(categoryId);

            _repository.Categoria.DeleteCategory(category);
            _repository.Save();
        }
        public void UpdateCategory(Guid categoryId, CategoriaForUpdateDTO categoryForUpdate, bool trackChanges)
        {
            var categoryEntity = _repository.Categoria.GetCategory(categoryId, trackChanges);
            if (categoryEntity == null)
                throw new CategoriaNotFoundException(categoryId);

            _mapper.Map(categoryForUpdate, categoryEntity);
            _repository.Save();
        }
    }
}
