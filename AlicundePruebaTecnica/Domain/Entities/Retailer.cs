using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Retailer
    {
        [Key]
        [Required]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(40)]
        public string ReName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(2)]
        public string Country { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(3)]
        public string CodingScheme { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string ReCode { get; set; }

        public Retailer()
        {
        }

        public Retailer(int reId, string reName, string country, string codingScheme, string reCode)
        {
            ReId = reId;
            ReName = reName;
            Country = country;
            CodingScheme = codingScheme;
            ReCode = reCode;
        }
    }
}
