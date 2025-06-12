using System.ComponentModel.DataAnnotations;

namespace RommelkoningenApi.Models
{
    public class FotoData
    {
        [Key]
        public Guid Foto_Id { get; set; }
        [Required]
        public DateTime Datum_En_Tijd { get; set; }
        [Required]
        public string Camera_Naam { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public string Postcode { get; set; }
        public string windrichting { get; set; }
        public int temperatuur { get; set; }
        public string Weer_Omschrijving { get; set; }
    }
}
