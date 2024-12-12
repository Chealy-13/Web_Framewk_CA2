namespace Web_Framewk_CA2.Components.Model
{
    public class NewsData
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public Article[] Articles { get; set; }
    }

    public class Article
    {
        public Source Source { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string PublishedAt { get; set; }
        public string Content { get; set; }
    }
    public class Source
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
