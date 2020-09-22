using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace srrdb.dbo
{
    public class Release
    {
        public int Id { get; set; }

        public DateTime AddedAt { get; set; }

        public string Title { get; set; } //release name, unique

        [StringLength(10)]
        public string ImdbId { get; set; }

        //relations
        public ICollection<Srr> Srrs { get; set; }

        public ICollection<SrrFileArchive> SrrFileArchive { get; set; }

        public ICollection<SrrFileRar> SrrFileRar { get; set; }

        public ICollection<SrrFileStore> SrrFileStore { get; set; }

        public ICollection<ReleaseTag> ReleaseTag { get; set; }

        public ICollection<Activity> Activity { get; set; }
    }
}
