namespace RachunkiTechniczneWebApi.DTOs.Admin
{
    public class ContractDto
    {
        public int Id_con {  get; set; }
        public DateTime OpeningDate { get; set; }
        public string ProductCode { get; set; }
        public string Contract { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
    }
}
