using System.ComponentModel.DataAnnotations;

namespace RommelkoningenApi.Models
{
    public class AfvalData
    {
        [Key]
        public Guid Afval_Id { get; set; }
        [Required]
        public Guid Foto_Id { get; set; }
        [Required]
        public string Afval_Type { get; set; }
        public float? Confidence { get; set; }
    }
}
