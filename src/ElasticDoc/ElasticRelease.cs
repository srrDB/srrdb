using Nest;
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

        public static void CreateIndex(IElasticClient client)
        {
            //client.Indices.DeleteAsync("release").Result;
            //client.Indices.GetAsync(new GetIndexRequest(Indices.All)).Result;

            CreateIndexResponse createIndexResponse = client.Indices.Create("release", c => c
                .Settings(s => s
                    .Analysis(a => a
                        .Analyzers(aa => aa
                            .Custom("rlsname_analyzer", ca => ca
                                .Tokenizer("rlsname_tokenizer")
                                .Filters("lowercase")
                            )
                        )
                        .Tokenizers(at => at
                            .Pattern("rlsname_tokenizer", pt => pt
                                .Pattern("[^A-Za-z0-9]+"))
                        )
                        .Normalizers(an => an
                            .Custom("lowercase_normalizer", cn => cn
                                .CharFilters()
                                .Filters("lowercase"))
                        )
                    )
                )
                .Map<ElasticRelease>(mm => mm
                    .Properties(p => p
                        .Text(t => t
                            .Name(n => n.Title)
                            .Analyzer("rlsname_analyzer")
                            .Fields(tf => tf
                                .Keyword(kw => kw
                                    .Name("keyword")
                                    .Normalizer("lowercase_normalizer")
                                )
                            )
                        )
                    )
                )
            );
        }
    }
}
