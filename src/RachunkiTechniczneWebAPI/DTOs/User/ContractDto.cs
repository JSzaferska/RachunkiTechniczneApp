namespace RachunkiTechniczneWebApi.DTOs.User
{
    public class ContractDto
    {
        public DateTime OpeningDate { get; set; }
        public string ProductCode { get; set; }
        public string Contract { get; set; }
        public string Currency { get; set; }
        public DateTime Date {  get; set; }
        public decimal Balance { get; set; }
    }
}
