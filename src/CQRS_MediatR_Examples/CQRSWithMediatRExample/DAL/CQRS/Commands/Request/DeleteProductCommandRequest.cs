using System.ComponentModel.DataAnnotations;
using CQRSWithMediatRExample.DAL.CQRS.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithMediatRExample.DAL.CQRS.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        [Required]
        [BindProperty(Name = "id")]
        public int Id { get; set; }
    }
}