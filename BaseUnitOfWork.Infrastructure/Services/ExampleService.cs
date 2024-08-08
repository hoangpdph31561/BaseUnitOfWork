using AutoMapper;
using BaseUnitOfWork.Application.DataTransferObjects.Example;
using BaseUnitOfWork.Application.DataTransferObjects.Example.Requests;
using BaseUnitOfWork.Application.Interfaces.IRepositories;
using BaseUnitOfWork.Application.Interfaces.IService;
using BaseUnitOfWork.Application.ValueObjects.Response;
using BaseUnitOfWork.Domain.Entities;
using BaseUnitOfWork.Infrastructure.Extensions.FluentValidationRules.Example;

namespace BaseUnitOfWork.Infrastructure.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private APIResponse _response;
        public ExampleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = new APIResponse();
        }
        public async Task<APIResponse> CreateExample(ExampleCreateRequest exampleCreateRequest, CancellationToken cancellationToken = default)
        {
            try
            {

                var exampleEntity = _mapper.Map<ExampleEntity>(exampleCreateRequest);
                exampleEntity.CreatedTime = DateTimeOffset.UtcNow;
                var validator = new ExampleValidator();
                var validationResult = await validator.ValidateAsync(exampleEntity, cancellationToken);
                if (!validationResult.IsValid)
                {
                    _response.ErrorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                }
                else
                {
                    await _unitOfWork.Example.AddAsync(exampleEntity, cancellationToken);
                    await _unitOfWork.SaveAsync(cancellationToken);
                    _response.IsSuccess = true;
                    _response.StatusCode = System.Net.HttpStatusCode.OK;
                }

            }
            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(e.Message);
            }
            return _response;
        }

        public async Task<APIResponse> DeleteExample(ExampleDeleteRequest exampleDeleteRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                var exampleEntity = _mapper.Map<ExampleEntity>(exampleDeleteRequest);
                exampleEntity.DeletedTime = DateTimeOffset.UtcNow;
                exampleEntity.Deleted = true;
                await _unitOfWork.Example.Remove(exampleEntity, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);
                _response.IsSuccess = true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return _response;
            }
        }

        public async Task<APIResponse> GetExample(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var example = await _unitOfWork.Example.GetAsync(x => x.Id == id, cancellationToken: cancellationToken);
                var result = _mapper.Map<ExampleDto>(example);
                _response.IsSuccess = true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = result;
                return _response;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return _response;
            }
        }

        public async Task<APIResponse> GetExamples(CancellationToken cancellationToken = default)
        {
            try
            {
                var lstExample = await _unitOfWork.Example.GetAllAsync(x => !x.Deleted && x.Status != Domain.Enums.EntityStatus.Deleted, cancellationToken: cancellationToken);
                var lstResult = _mapper.Map<IEnumerable<ExampleDto>>(lstExample);
                _response.IsSuccess = true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                _response.Result = lstResult;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
                return _response;
            }
        }

        public async Task<APIResponse> UpdateExample(ExampleUpdateRequest exampleUpdateRequest, CancellationToken cancellationToken = default)
        {
            try
            {
                var exampleEntity = _mapper.Map<ExampleEntity>(exampleUpdateRequest);
                var exampleValidator = new ExampleValidator();
                var validationResult = await exampleValidator.ValidateAsync(exampleEntity, cancellationToken);
                if (!validationResult.IsValid)
                {
                    _response.ErrorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                }
                else
                {
                    await _unitOfWork.Example.Update(exampleEntity, cancellationToken);
                    await _unitOfWork.SaveAsync(cancellationToken);
                    _response.IsSuccess = true;
                    _response.StatusCode = System.Net.HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                _response.ErrorMessages.Add(ex.Message);
            }
            return _response;
        }

    }
}
