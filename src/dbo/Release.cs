using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using srrdb.ElasticDoc;

namespace srrdb.dbo
{
    public class Release
    {
        public int Id { get; set; }

        public DateTime AddedAt { get; set; }

        public string Title { get; set; } //release name, unique

        [StringLength(10)]
        public string ImdbId { get; set; } //TODO: remove and use ExternalMedia instead?

        public int ExternalMediaId { get; set; }

        public virtual ExternalMedia ExternalMedia { get; set; }

        //relations
        public virtual Srr Srr { get; set; }

        public ICollection<ReleaseTag> ReleaseTag { get; set; }

        public ICollection<Activity> Activity { get; set; }

        public ICollection<Download> Download { get; set; }

        //elastic
        public static explicit operator ElasticRelease(Release release)
        {
            bool hasSrr = release.Srr != null;

            ElasticRelease elasticRelease = new ElasticRelease
            {
                Id = release.Id,
                Title = release.Title,

                //HasSrr = hasSrr,
                SrrId = hasSrr ? release.Srr.Id : null,
                SrrHasNfo = hasSrr ? release.Srr.HasNfo : false,
                SrrHasSrs = hasSrr ? release.Srr.HasSrs : false,

                ImdbId = release.ImdbId,
                Activity = (release.Activity ?? new List<Activity>()).Select(x => new ElasticActivity
                {
                    Type = x.ActivityTypeId,
                    Text = x.ActivityType.Text
                }).ToArray()
            };

            //(has srr?) data
            if (hasSrr)
            {
                elasticRelease.StoredFiles = release.Srr.SrrFileStore.Select(x => new ElasticFile
                {
                    FileName = x.File.FileName,
                    FileSize = x.File.FileSize,
                    Crc32 = x.File.Crc32,
                    TTH = x.File.TTH
                }
                ).ToArray();

                elasticRelease.RarFiles = release.Srr.SrrFileRar.Select(x => new ElasticFile
                {
                    FileName = x.File.FileName,
                    FileSize = x.File.FileSize,
                    Crc32 = x.File.Crc32,
                    TTH = x.File.TTH
                }
                ).ToArray();

                elasticRelease.ArchivedFiles = release.Srr.SrrFileArchive.Select(x => new ElasticFile
                {
                    FileName = x.File.FileName,
                    FileSize = x.File.FileSize,
                    Crc32 = x.File.Crc32,
                    TTH = x.File.TTH
                }
                ).ToArray();
            }

            return elasticRelease;
        }
    }
}
