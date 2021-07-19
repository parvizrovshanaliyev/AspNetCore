using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithoutMediatRExample.DAL.CQRS.Commands.Request
{
    public class DeleteProductCommandRequest
    {
        [Required]
        [BindProperty(Name = "id")]
        public int Id { get; set; }
    }
}