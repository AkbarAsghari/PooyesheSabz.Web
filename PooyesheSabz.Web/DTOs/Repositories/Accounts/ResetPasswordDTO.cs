﻿using System.ComponentModel.DataAnnotations;

namespace PooyesheSabz.Web.DTOs.Repositories.Accounts
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
