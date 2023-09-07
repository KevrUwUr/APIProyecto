using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyect.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Proyect.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoriasController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categorias = _service.CategoriaService.GetAllCategories(trackChanges:false);
            return Ok(categorias);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetCategory(Guid Id)
        {
            var categoria = _service.CategoriaService.GetCategory(Id, trackChanges: false);
            return Ok(categoria);
        }
        [HttpPost]
        public IActionResult Createcategory([FromBody] CategoriaForCreationDTO category)
        {
            if (category == null)
            {
                return BadRequest("CategoriaForCreationDTO object is null");
            }
            var createdcategory = _service.CategoriaService.CreateCategory(category);

            return CreatedAtRoute("CategoryById", new { id = createdcategory.Id },
            createdcategory);
        }

        [HttpGet("collection/({ids})", Name = "CategoryCollection")]
        public IActionResult GetcategoryCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var categories = _service.CategoriaService.GetByIds(ids, trackChanges: false);
            return Ok(categories);
        }

        [HttpPost("collection")]
        public IActionResult CreateCategoryCollection([FromBody]
        IEnumerable<CategoriaForCreationDTO> categoryCollection)
        {
            var result =
            _service.CategoriaService.CreateCategoryCollection(categoryCollection);
            return CreatedAtRoute("CategoryCollection", new { result.ids },
            result.categorias);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCategory(Guid id)
        {
            _service.CategoriaService.DeleteCategory(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateCategory(Guid id, [FromBody] CategoriaForUpdateDTO category)
        {
            if (category == null)
                return BadRequest("categoryForUpdateDTO object is null");

            _service.CategoriaService.UpdateCategory(id, category, trackChanges: true);
            return NoContent();
        }
    }
}
