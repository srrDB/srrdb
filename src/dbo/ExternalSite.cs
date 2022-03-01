using System.Collections.Generic;

namespace srrdb.dbo
{
    public class ExternalSite
    {
        public string Id { get; set; }

        public string Title { get; set; } //IMdb, TheTVDB, IGDB, (AllMusic, MusicBrainz, Discogs, Last.fm), Rotten Tomatoes, IGN, GameFAQ...

        public string StartPage { get; set; }

        public ICollection<ExternalMedia> ExternalMedia { get; set; }
    }
}
