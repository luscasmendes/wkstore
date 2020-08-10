using System.ComponentModel.DataAnnotations;

namespace wkapi.Models
{

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Title { get; set; }

    }

}