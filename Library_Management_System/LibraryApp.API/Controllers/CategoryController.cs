using LibraryApp.Application.Features.CategoryFeature.Command.AddCategory;
using LibraryApp.Application.Features.CategoryFeature.Command.DeleteCategory;
using LibraryApp.Application.Features.CategoryFeature.Command.UpdateCategory;
using LibraryApp.Application.Features.CategoryFeature.Query.GetCategories;
using LibraryApp.Application.Features.CategoryFeature.Query.GetCategoryById;
using LibraryApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administartor")]
    public class CategoryController : ControllerBase
    {
        readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var allCategories = await _mediator.Send(new GetCategoriesQuery());
            return Ok(allCategories);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(Category category)
        {
            var result = await _mediator.Send(new AddCategoryCommand(category));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(int id, [FromBody] Category category)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand(id, category.Name, category.Description));
            return Ok(result);
        }

    }
}
