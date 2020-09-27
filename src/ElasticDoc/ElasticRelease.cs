using System;
using System.Collections.Generic;
using System.Text;
using srrdb.dbo;

namespace srrdb.ElasticDoc
{
    public class ElasticFile
    {
        public string FileName { get; set; }

        public ulong FileSize { get; set; }

        public uint Crc32 { get; set; } //int format

        public string TTH { get; set; }
    }

    public class ElasticActivity
    {
        public int Type { get; set; }

        public string Text { get; set; }
    }

    public class ElasticTag
    {
        public int Type { get; set; }

        public string Tag { get; set; }
    }

    public class ElasticRelease
    {
        public string Title { get; set; }

        public bool HasSrr { get; set; }

        public string ImdbId { get; set; }

        public ElasticFile[] StoredFiles { get; set; }

        public ElasticFile[] RarFiles { get; set; }

        public ElasticFile[] ArchivedFiles { get; set; }

        public ElasticActivity[] Activity { get; set; }

        public ElasticTag[] Tags { get; set; }

        public static implicit operator Release(ElasticRelease er)
        {
            return new Release();
        }

    }
}
