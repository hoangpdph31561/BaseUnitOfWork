namespace BaseUnitOfWork.Application.DataTransferObjects.Example.Requests
{
    public class ExampleCreateRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid? CreatedBy { get; set; }
    }
}
