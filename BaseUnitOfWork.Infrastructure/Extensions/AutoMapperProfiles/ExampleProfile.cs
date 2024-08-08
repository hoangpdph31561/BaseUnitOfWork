using AutoMapper;
using BaseUnitOfWork.Application.DataTransferObjects.Example;
using BaseUnitOfWork.Application.DataTransferObjects.Example.Requests;
using BaseUnitOfWork.Domain.Entities;

namespace BaseUnitOfWork.Infrastructure.Extensions.AutoMapperProfiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<ExampleEntity, ExampleDto>();
            CreateMap<ExampleCreateRequest, ExampleEntity>();
            CreateMap<ExampleUpdateRequest, ExampleEntity>();
        }
    }
}
