using System.ComponentModel.DataAnnotations;

namespace CRUDAPIWEB.Models
{
    public class Brand
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] public string Category { get; set; }
        [Required] public double Price { get; set; }

        public string ImagePath { get; set; } = null!;

    }
}
