namespace srrdb.dbo
{
    public class Tag
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; } //what kind of type of tag it is: "language","country","group","foreign","quality","source" etc.
    }
}
