using System.ComponentModel.DataAnnotations;

namespace Example1.Models.ModelMetadataTypes
{
    
    public class ProductMetadata
    {
        [Required(ErrorMessage = "Daxil Edimelidir.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Daxil edilmelidir.")]
        [EmailAddress(ErrorMessage = "Daxil edilen email formasi duzgun deyil .")]
        public string Email { get; set; }
    }
}
