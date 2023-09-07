using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICategoriaService
    {
        IEnumerable<CategoriaDTO> GetAllCategories(bool trackChanges);
        CategoriaDTO GetCategory(Guid Id, bool trackChanges);
        CategoriaDTO CreateCategory(CategoriaForCreationDTO category);
        IEnumerable<CategoriaDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<CategoriaDTO> categorias, string ids) CreateCategoryCollection
            (IEnumerable<CategoriaForCreationDTO> categoryCollection);
        void DeleteCategory(Guid categoryId, bool trackChanges);
        void UpdateCategory(Guid categoryId, CategoriaForUpdateDTO categoryForUpdate, bool trackChanges);
    }
}
