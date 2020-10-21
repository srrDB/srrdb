using System;
using srrdb.dbo.Account;

namespace srrdb.dbo
{
    public class UserPasswordRecovery
    {
        public int Id { get; set; }

        public DateTime RecoveryCodeAt { get; set; }

        public string RecoveryCode { get; set; }

        public string Email { get; set; }

        public string ByIP { get; set; }

        public int? UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
