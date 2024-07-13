﻿namespace RachunkiTechniczneWebApi.DTOs.Admin
{
    public class AddContractRegistryDto
    {        
        public string Owner { get; set; }
        public DateTime OpeningDate { get; set; }
        public string ProductCode { get; set; }
        public string Contract { get; set; }
        public string Currency { get; set; }
        public string Account { get; set; }
        public string SubAccount { get; set; }

    }
}
