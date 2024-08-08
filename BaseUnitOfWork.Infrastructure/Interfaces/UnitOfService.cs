using AutoMapper;
using BaseUnitOfWork.Application.Interfaces.IRepositories;
using BaseUnitOfWork.Application.Interfaces.IService;

namespace BaseUnitOfWork.Infrastructure.Interfaces
{
    public class UnitOfService : IUnitOfService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public IExampleService ExampleService { get; private set; }

        public UnitOfService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            ExampleService = new ExampleService(unitOfWork, mapper);
        }
    }
}
