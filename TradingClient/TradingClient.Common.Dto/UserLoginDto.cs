using System.ComponentModel.DataAnnotations;

namespace TradingClient.Common.Dto
{
    public class UserLoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
