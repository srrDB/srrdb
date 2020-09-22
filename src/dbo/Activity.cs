using System;

using srrdb.dbo.Account;

namespace srrdb.dbo
{
    public class Activity
    {
        public int Id { get; set; }

        public string Ua { get; set; } //user agent

        public string Ip { get; set; }

        public DateTime ActivityAt { get; set; }

        //relations
        public int? UserId { get; set; }
        public virtual ApplicationUser ActivityBy { get; set; }

        public int ActivityTypeId { get; set; }
        public virtual ActivityType ActivityType { get; set; }

        public int? ReleaseId { get; set; }
        public virtual Release Release { get; set; }
    }
}
