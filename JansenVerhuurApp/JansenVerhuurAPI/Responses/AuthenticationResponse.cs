using System.Collections.Generic;

namespace JansenVerhuurAPI.Responses
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }

        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}