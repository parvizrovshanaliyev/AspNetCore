using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithoutMediatRExample.DAL.CQRS.Queries.Request
{
    public class GetByIdProductQueryRequest
    {
        [Required]
        [BindProperty(Name = "id")]
        public int Id { get; set; }
    }
}