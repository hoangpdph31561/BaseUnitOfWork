using BaseUnitOfWork.Domain.Entities.Base;
using BaseUnitOfWork.Domain.Enums;

namespace BaseUnitOfWork.Domain.Entities
{
    public class ExampleEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
