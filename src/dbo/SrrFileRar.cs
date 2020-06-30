namespace srrdb.dbo
{
    public class SrrFileRar
    {
        public int Id { get; set; }

        //relations
        public int FileId { get; set; }
        public File File { get; set; }

        public int ReleaseId { get; set; }
        public Release Release { get; set; }
    }
}
