using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using srrdb.dbo.Account;

namespace srrdb.dbo
{
    public class Srr
    {
        public int Id { get; set; }

        public DateTime UploadedAt { get; set; }

        public bool HasNfo { get; set; }

        public bool HasSrs { get; set; }

        [StringLength(42)]
        public string RarHash { get; set; }

        public bool IsCompressed { get; set; }
        //relations

        public int? UploadedById { get; set; }
        public ApplicationUser UploadedBy { get; set; }

        public int ReleaseId { get; set; }
        public virtual Release Release { get; set; }

        public ICollection<SrrFileArchive> SrrFileArchive { get; set; }

        public ICollection<SrrFileRar> SrrFileRar { get; set; }

        public ICollection<SrrFileStore> SrrFileStore { get; set; }
    }
}