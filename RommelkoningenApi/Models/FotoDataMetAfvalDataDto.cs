namespace RommelkoningenApi.Models
{
    public class FotoDataMetAfvalDataDto
    {
        public Guid Foto_Id { get; set; }
        public DateTime Datum_En_Tijd { get; set; }
        public string Camera_Naam { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Postcode { get; set; }
        public string Windrichting { get; set; }
        public int Temperatuur { get; set; }
        public string Weer_Omschrijving { get; set; }
        public List<AfvalDataDto> AfvalData { get; set; }   
    }
}
