using System.ComponentModel.DataAnnotations;

namespace Trading.Web.Dto
{
    public class UserLoginDto
    {
        public UserLoginDto()
        {
        }

        [Required]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }
    }
}
