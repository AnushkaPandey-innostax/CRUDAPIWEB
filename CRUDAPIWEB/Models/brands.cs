using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDAPIWEB.Models
{
    public class brands
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public double Price  { get; set; }
        
            }
}
