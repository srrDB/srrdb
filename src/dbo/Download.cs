using System;
using System.ComponentModel.DataAnnotations;
using srrdb.dbo.Account;

namespace srrdb.dbo
{
    public class Download
    {
        public int Id { get; set; }

        public DateTime DownloadAt { get; set; }

        [Required]
        public string Ip { get; set; } //to potentially avoid hammering

        public string File { get; set; } //null when downloading the complete srr

        //relations
        public virtual Release Release { get; set; }

        public int ReleaseId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int? UserId { get; set; } //null for non-logged in (limit on IP)
    }
}
