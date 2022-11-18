using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace srrdb.dbo.Models.Legacy
{
    [Table("download")]
    public class Download
    {
        [Key]
        [Column("fldID")]
        public int Id { get; set; }

        [Column("fldIP")]
        public string Ip { get; set; }

        [Column("fldName")]
        public string Name { get; set; }

        [Column("fldFile")]
        public string? File { get; set; }

        [Column("fldDate")]
        public DateTime DownloadedAt { get; set; }

        [Column("fldBy")]
        public int? UserId { get; set; }

        //public virtual User User { get; set; } //no relation to user right now (missing object)
    }
}
