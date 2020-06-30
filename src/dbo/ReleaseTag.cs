namespace srrdb.dbo
{
    public class ReleaseTag
    {
        public int Id { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public int ReleaseId { get; set; }
        public Release Release { get; set; }
    }
}
