﻿namespace GPB.Application.Dtos.AdminDto
{
    public class UpdateAdminDto
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}
