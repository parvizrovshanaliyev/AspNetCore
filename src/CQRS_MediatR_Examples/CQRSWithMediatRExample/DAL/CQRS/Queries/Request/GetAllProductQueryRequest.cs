using System.Collections.Generic;
using CQRSWithMediatRExample.DAL.CQRS.Queries.Response;
using MediatR;

namespace CQRSWithMediatRExample.DAL.CQRS.Queries.Request
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {
    }
}
