using System.Collections.Generic;

namespace Health.Api.Contracts.Responses
{
    public class AuthFailureResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
