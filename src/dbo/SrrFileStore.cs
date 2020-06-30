namespace srrdb.dbo
{
    public class SrrFileStore
    {
        public int Id { get; set; }

        //relations
        public int FileId { get; set; }
        public File File { get; set; }

        public int ReleaseId { get; set; }
        public Release Release { get; set; }
    }
}
