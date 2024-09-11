using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    [Table("Retailer", Schema = "marketParties")]
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

        [Required]
        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UTCCreatedDateTime { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UTCUpdatedDateTime { get; set; }

        public Retailer()
        {
        }

        public Retailer(int reId, string reName, string country, string codingScheme, string reCode, DateTime uTCCreatedDateTime, DateTime uTCUpdatedDateTime)
        {
            ReId = reId;
            ReName = reName;
            Country = country;
            CodingScheme = codingScheme;
            ReCode = reCode;
            UTCCreatedDateTime = uTCCreatedDateTime;
            UTCUpdatedDateTime = uTCUpdatedDateTime;
        }
    }
}
