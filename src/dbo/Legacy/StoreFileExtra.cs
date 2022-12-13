using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace srrdb.dbo.Legacy
{
    [Table("store_file_extra")]
    public class StoreFileExtra
    {
        [Key]
        [Column("fldID")]
        public int Id { get; set; }

        [Column("fldStoreFileID")]
        [ForeignKey(nameof(StoreFile))]
        public int StoreFileId { get; set; }

        [Column("fldData")]
        public string Json { get; set; }

        public virtual StoreFile StoreFile { get; set; }
    }
}
