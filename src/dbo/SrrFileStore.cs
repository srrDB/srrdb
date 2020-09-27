namespace srrdb.dbo
{
    public class SrrFileStore
    {
        public int Id { get; set; }

        //relations
        public int FileId { get; set; }
        public File File { get; set; }

        public int SrrId { get; set; }
        public Srr Srr { get; set; }
    }
}
