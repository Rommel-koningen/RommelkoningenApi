namespace RommelkoningenApi.Models
{
    public class AfvalDataDto
    {
        public Guid Afval_Id { get; set; }
        public string Afval_Type { get; set; }
        public float Confidence { get; set; }
    }
}
