namespace srrdb.dbo
{
    public class SrrFileRar
    {
        public int Id { get; set; }

        //relations
        public int FileId { get; set; }
        public virtual File File { get; set; }

        public int SrrId { get; set; }
        public virtual Srr Srr { get; set; }
    }
}
