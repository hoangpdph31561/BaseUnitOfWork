﻿namespace BaseUnitOfWork.Application.DataTransferObjects.Example.Requests
{
    public class ExampleUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid? ModifiedBy { get; set; }

    }
}
