using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public IEnumerable<Categoria> GetAllCategories(bool trackChanges)=>
            FindAll(trackChanges)
                .OrderBy(c => c.Nombre)
                .ToList();

        public Categoria GetCategory(Guid Id, bool trackChanges) =>
            FindByCondition(c => c.IdCategoria.Equals(Id), trackChanges)
            .SingleOrDefault();

        public void CreateCategory(Categoria category) => Create(category);
        public IEnumerable<Categoria> GetByIds(IEnumerable<Guid> ids, bool trackChanges)=>
            FindByCondition(x=>ids.Contains(x.IdCategoria), trackChanges)
            .ToList();
        public void DeleteCategory(Categoria category) => Delete(category);
    }
}
