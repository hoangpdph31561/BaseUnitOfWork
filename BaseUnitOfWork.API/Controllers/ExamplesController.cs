using BaseUnitOfWork.Application.DataTransferObjects.Example.Requests;
using BaseUnitOfWork.Application.Interfaces.IService;
using BaseUnitOfWork.Application.ValueObjects.Request;
using Microsoft.AspNetCore.Mvc;

namespace BaseUnitOfWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        private readonly IUnitOfService _unitOfService;
        public ExamplesController(IUnitOfService unitOfService)
        {
            _unitOfService = unitOfService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            var response = await _unitOfService.ExampleService.GetExamples(cancellationToken);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken = default)
        {
            var response = await _unitOfService.ExampleService.GetExample(id, cancellationToken);
            return Ok(response);
        }
        [HttpGet("pagination")]
        public async Task<IActionResult> Get([FromQuery] PaginationRequest paginationRequest, CancellationToken cancellationToken = default)
        {
            var response = await _unitOfService.ExampleService.GetExamplesWithPagination(paginationRequest, cancellationToken);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExampleCreateRequest exampleCreateRequest, CancellationToken cancellationToken = default)
        {
            var response = await _unitOfService.ExampleService.CreateExample(exampleCreateRequest, cancellationToken);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ExampleUpdateRequest exampleUpdateRequest, CancellationToken cancellationToken = default)
        {
            var response = await _unitOfService.ExampleService.UpdateExample(exampleUpdateRequest, cancellationToken);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] ExampleDeleteRequest exampleDeleteRequest, CancellationToken cancellationToken = default)
        {
            var response = await _unitOfService.ExampleService.DeleteExample(exampleDeleteRequest, cancellationToken);
            return Ok(response);
        }

    }
}
