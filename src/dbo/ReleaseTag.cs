namespace srrdb.dbo
{
    public class ReleaseTag
    {
        public int Id { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public int ReleaseId { get; set; }
        public virtual Release Release { get; set; }
    }
}
