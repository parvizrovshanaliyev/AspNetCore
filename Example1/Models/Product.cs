using Example1.Models.ModelMetadataTypes;
using Microsoft.AspNetCore.Mvc;

namespace Example1.Models
{
    //[ModelMetadataType(typeof(ProductMetadata))]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Email { get; set; }
    }
}
