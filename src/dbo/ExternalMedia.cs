using System.Collections.Generic;

namespace srrdb.dbo
{
    public class ExternalMedia
    {
        public int Id { get; set; }

        public string Url { get; set; }

        //https://www.imdb.com/title/tt0816692/
        //https://thetvdb.com/series/the-simpsons
        //https://www.igdb.com/games/grand-theft-auto-v
        //https://www.allmusic.com/album/sounds-of-silence-mw0000195709
        public string UniqueId { get; set; }

        public int ExternalSideId { get; set; }

        public virtual ExternalSite ExternalSite { get; set; }

        public int ReleaseId { get; set; }

        public ICollection<Release> Release { get; set; }
    }
}
