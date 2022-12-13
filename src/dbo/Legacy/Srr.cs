using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace srrdb.dbo.Legacy
{
    [Table("file")]
    public class Srr
    {
        [Key]
        [Column("fldName")]
        public string Title { get; set; }

        [Column("fldCategory")]
        public int CategoryId { get; set; } //TODO: enum/relation?

        [NotMapped]
        public bool Compressed
        {
            get
            {
                return this.fldCompressed == "yes";
            }
        }

        [Column("fldCompressed")]
        public string fldCompressed { get; set; } //enum yes/no

        [NotMapped]
        public bool Approved
        {
            get
            {
                return this.fldConfirmed == "yes";
            }
        }

        [Column("fldConfirmed")]
        public string fldConfirmed { get; set; } //enum yes/no //approved/confirmed

        [Column("fldDate")]
        public DateTime AddedOn { get; set; }

        [NotMapped]
        public bool Foreign
        {
            get
            {
                return this.fldForeign == "yes";
            }
        }

        [Column("fldForeign")]
        public string fldForeign { get; set; } //english or not, enum yes/no

        [Column("fldGroup")]
        public string Group { get; set; }

        [Column("fldImdb")]
        public string Imdb { get; set; }

        [NotMapped]
        public bool Nfo
        {
            get
            {
                return this.fldNfo == "yes";
            }
        }

        [Column("fldNFO")]
        public string fldNfo { get; set; } //enum yes/no

        [NotMapped]
        public bool Srs
        {
            get
            {
                return this.fldSrs == "yes";
            }
        }

        [Column("fldSRS")]
        public string fldSrs { get; set; } //enum yes/no/broken

        [Column("fldNote")]
        public string Note { get; set; }

        [NotMapped]
        public bool Nuked
        {
            get
            {
                return this.fldNuked == "yes";
            }
        }

        [Column("fldNuked")]
        public string fldNuked { get; set; } //enum yes/no

        [Column("fldRarHash")]
        public string RarHash { get; set; }

        [Column("fldUploader")]
        public int? UploaderId { get; set; }

        [Column("fldVersion")]
        public int Version { get; set; }
    }
}
