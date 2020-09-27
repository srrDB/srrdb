using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public string ImdbId { get; set; }

        //relations
        public int? SrrId { get; set; }

        [JsonIgnore]
        public Srr Srr { get; set; }

        [JsonIgnore]
        public ICollection<ReleaseTag> ReleaseTag { get; set; }

        [JsonIgnore]
        public ICollection<Activity> Activity { get; set; }

        public static explicit operator ElasticRelease(Release release)
        {
            bool hasSrr = release.Srr != null;

            ElasticRelease elasticRelease = new ElasticRelease
            {
                Title = release.Title,
                HasSrr = hasSrr,
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
