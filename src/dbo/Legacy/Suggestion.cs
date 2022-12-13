using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace srrdb.dbo.Legacy
{
    [Table("suggestion")]
    public class Suggestion
    {
        [Key]
        [Column("fldID")]
        public int Id { get; set; }

        [Column("fldName")]
        public string Title { get; set; }

        [Column("fldFilename")]
        public string Filename { get; set; }

        [Column("fldFilesize")]
        public int Filesize { get; set; }

        [Column("fldBy")]
        public int? AddedBy { get; set; }

        [Column("fldCRC")]
        public string CRC { get; set; }

        [Column("fldNote")]
        public string? Note { get; set; }

        [Column("fldVerifiedSample")]
        public int? fldVerifiedSample { get; set; } //nullable bool

        [NotMapped]
        public bool? VerifiedSample
        {
            get
            {
                if (this.fldVerifiedSample == 1)
                {
                    return true;
                }
                else if (this.fldVerifiedSample == 0)
                {
                    return false;
                }

                return null;
            }
        }

        [Column("fldRealFilename")]
        public string? RealFilename { get; set; }

        [Column("fldRealFilesize")]
        public ulong? RealFilesize { get; set; }

        [Column("fldRealCRC")]
        public string? RealCRC { get; set; }
    }
}
