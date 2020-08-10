using System.ComponentModel.DataAnnotations;

namespace wkapi.Models
{

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Title { get; set; }

    }

}