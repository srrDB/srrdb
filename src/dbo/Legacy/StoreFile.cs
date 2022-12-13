using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace srrdb.dbo.Legacy
{
    [Table("store_file")]
    public class StoreFile
    {
        [Key]
        [Column("fldID")]
        public int Id { get; set; }

        [Column("fldName")]
        public string Title {  get; set; }

        [Column("fldFilename")]
        public string Filename {  get; set; }

        [Column("fldFilesize")]
        public UInt64 Filesize { get; set; }

        [Column("fldCRC")]
        public string CRC { get; set; }

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
        public string? RealFilename {  get; set; }

        [Column("fldRealFilesize")]
        public ulong? RealFileSize { get; set; }

        [Column("fldRealCRC")]
        public string RealCRC {  get; set; }

        [Column("fldRealTTH")]
        public string RealTTH {  get; set; }

        public List<StoreFileExtra> StoreFileExtra { get; set; }  
    }
}
