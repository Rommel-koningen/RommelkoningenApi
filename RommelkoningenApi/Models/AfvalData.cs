namespace RommelkoningenApi.Models
{
    public class AfvalData
    {
        public Guid Afval_Id { get; set; }
        public Guid Foto_Id { get; set; }
        public string Afval_Type { get; set; }
        public float Confidence { get; set; }
    }
}
