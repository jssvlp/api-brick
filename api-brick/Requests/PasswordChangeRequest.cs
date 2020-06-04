using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Requests
{
    public class PasswordChangeRequest
    {
        public string RecoveryToken { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
    }
}
