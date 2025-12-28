using System.ComponentModel.DataAnnotations;

namespace TP08.Models.Dtos
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Le nom du produit est obligatoire")]
        [MinLength(3, ErrorMessage = "Le nom doit contenir au moins 3 caractères")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        public double Price { get; set; }
    }
}
