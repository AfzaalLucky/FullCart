using FullCart.API.CustomActionFilters;
using FullCart.Application.Features.Brands.Commands.CreateBrand;
using FullCart.Application.Features.Brands.Commands.DeleteBrandById;
using FullCart.Application.Features.Brands.Commands.UpdateBrand;
using FullCart.Application.Features.Brands.Queries.GetAllBrands;
using FullCart.Application.Features.Brands.Queries.GetBrandById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseApiController
    {
        // POST api/controller
        [HttpPost]
        public async Task<IActionResult> Post(CreateBrandCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // GET api/controller
        [HttpGet]
        [ValidateModel]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] GetAllBrandsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllBrandsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/controller/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetBrandByIdQuery { Id = id }));
        }

        // PUT api/controller/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateBrandCommand command)
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
            return Ok(await Mediator.Send(new DeleteBrandByIdCommand { Id = id }));
        }
    }
}
