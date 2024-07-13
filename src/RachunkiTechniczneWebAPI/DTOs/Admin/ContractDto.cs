namespace RachunkiTechniczneWebApi.DTOs.Admin
{
    public class ContractDto
    {
        public int ContractId { get; set; }
        public string Owner { get; set; }
        public DateTime OpeningDate { get; set; }
        public string ProductCode { get; set; }
        public string Contract { get; set; }
        public string Currency { get; set; }
        public DateTime Date {  get; set; }
        public decimal Balance { get; set; }
        public string Account { get; set; }
        public string SubAccount { get; set; }
        public int IsCorrect { get; set; }
        public float CorrectBalance { get; set; }
        public string Comment { get; set; }

    }
}
