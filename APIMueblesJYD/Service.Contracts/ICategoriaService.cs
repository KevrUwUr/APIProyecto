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
    }
}
