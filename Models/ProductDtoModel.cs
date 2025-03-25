using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendExam.Models
{ 
    public class ProductDtoModel
    { 
        [Column("code")]
        [Required]
        [StringLength(50)]

        public string? Code { get; set; }

        [Column("name")]
        public string? Name { get; set; }
    }
}
