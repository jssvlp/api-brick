using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_brick.Models
{
    [Table("passwords_resets")]
    public class PasswordReset
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RecoveryToken { get; set; }
        public string UserRecoveryToken { get; set; }
        public DateTime RequestDateTime { get; set; }

    }
}
