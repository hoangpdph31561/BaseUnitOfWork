namespace BaseUnitOfWork.Application.DataTransferObjects.Example
{
    public class ExampleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    }
}
