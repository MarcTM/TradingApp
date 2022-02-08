using System;

namespace Trading.Application.Services.Jwt
{
    public class UserTokens
    {
        public string Token { get; set; }

        public Guid Guid { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public TimeSpan Validaty { get; set; }
    }
}
