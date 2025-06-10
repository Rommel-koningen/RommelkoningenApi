namespace RommelkoningenApi.Models
{
    public class FotoData
    {
        public Guid Foto_Id { get; set; }
        public DateTime Datum_En_Tijd { get; set; }
        public string Camera_Naam { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Postcode { get; set; }
        public string windrichting { get; set; }
        public int temperatuur { get; set; }
        public string Weer_Omschrijving { get; set; }
    }
}
