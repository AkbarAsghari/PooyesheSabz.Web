using System.ComponentModel.DataAnnotations;

namespace PooyesheSabz.Web.DTOs.Repositories.Accounts
{
    public class ForgetPasswordDTO
    {
        [Required]
        public string Email { get; set; }
    }
}
