using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUnitOfWork.Application.ValueObjects.Request
{
    public record PaginationRequest(int Page = 1, int PageSize = 10);
}
