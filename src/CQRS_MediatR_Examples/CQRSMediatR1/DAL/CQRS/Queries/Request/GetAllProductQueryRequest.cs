using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSMediatR1.CQRS.Queries.Request
{
    public class GetAllProductQueryRequest
    {
    }

    public class GetByIdProductQueryRequest
    {
        public Guid Id { get; set; }
    }
}
