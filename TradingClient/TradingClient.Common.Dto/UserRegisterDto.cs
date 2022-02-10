using System.ComponentModel.DataAnnotations;

namespace TradingClient.Common.Dto
{
    public class UserRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string RPassword { get; set; }
    }
}
