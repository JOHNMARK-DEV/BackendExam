using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackendExam.Models
{
    [Table("setup_product")]
    public class ProductModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("code")]
        [Required]
        [StringLength(50)]

        public string? Code { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        public static implicit operator ProductModel(ProductDtoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
