
using FullCart.Application.Features.Categories.Commands.CreateCategory;
using FullCart.Application.Features.Categories.Commands.DeleteCategoryById;
using FullCart.Application.Features.Categories.Commands.UpdateCategory;
using FullCart.Application.Features.Categories.Queries.GetAllCategories;
using FullCart.Application.Features.Categories.Queries.GetCategoryById;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {// GET: api/controller
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCategoriesParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllCategoriesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/controller/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCategoryByIdQuery { Id = id }));
        }

        // POST api/controller
        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/controller/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/controller/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCategoryByIdCommand { Id = id }));
        }
    }
}
