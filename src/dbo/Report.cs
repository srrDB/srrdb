using srrdb.dbo.Account;

namespace srrdb.dbo
{
    public class Report
    {
        public int Id { get; set; }

        //user submitted text
        public string Text { get; set; }

        public int? ReportedById { get; set; }

        public virtual ApplicationUser ReportedBy { get; set; }

        public int? SrrId { get; set; }
        public virtual Srr Srr { get; set; }

        public int? ReleaseId { get; set; }

        public virtual Release Release { get; set; }

        public int? FileId { get; set; }
    }
}
