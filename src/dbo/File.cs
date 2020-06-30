using System.ComponentModel.DataAnnotations;

namespace srrdb.dbo
{
    public class File
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string FileName { get; set; }

        public ulong FileSize { get; set; }

        public uint Crc32 { get; set; } //int format

        [MaxLength(39)]
        public string TTH { get; set; }
    }
}
