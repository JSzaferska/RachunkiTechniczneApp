namespace RachunkiTechniczneWebApi.DTOs.User
{
    public class UpdateUserContractDto
    {
        public int ContractId { get; set; }
        public int IsCorrect { get; set; }
        public float CorrectBalance { get; set; }
        public string comment { get; set; }
    }
}
