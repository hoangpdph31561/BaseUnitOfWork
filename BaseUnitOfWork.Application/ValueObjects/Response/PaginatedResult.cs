using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUnitOfWork.Application.ValueObjects.Response
{
    public class PaginatedResult<TEntity> where TEntity : class
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
    }

}
