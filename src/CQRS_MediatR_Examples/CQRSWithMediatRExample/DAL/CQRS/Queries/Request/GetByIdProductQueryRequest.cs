using System.ComponentModel.DataAnnotations;
using CQRSWithMediatRExample.DAL.CQRS.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithMediatRExample.DAL.CQRS.Queries.Request
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        [Required]
        [BindProperty(Name = "id")]
        public int Id { get; set; }
    }
}