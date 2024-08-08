using BaseUnitOfWork.Application.DataTransferObjects.Example.Requests;
using BaseUnitOfWork.Application.ValueObjects.Response;

namespace BaseUnitOfWork.Application.Interfaces.IService
{
    public interface IExampleService
    {
        Task<APIResponse> GetExamples(CancellationToken cancellationToken = default);
        Task<APIResponse> GetExample(Guid id, CancellationToken cancellationToken = default);
        Task<APIResponse> CreateExample(ExampleCreateRequest exampleCreateRequest, CancellationToken cancellationToken = default);
        Task<APIResponse> UpdateExample(ExampleUpdateRequest exampleUpdateRequest, CancellationToken cancellationToken = default);
        Task<APIResponse> DeleteExample(ExampleDeleteRequest exampleDeleteRequest, CancellationToken cancellationToken = default);

    }
}
