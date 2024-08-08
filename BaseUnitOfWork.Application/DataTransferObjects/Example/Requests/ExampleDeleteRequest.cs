namespace BaseUnitOfWork.Application.DataTransferObjects.Example.Requests
{
    public class ExampleDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }

    }
}
