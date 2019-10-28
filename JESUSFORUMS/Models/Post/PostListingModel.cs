using JESUSFORUMS.Models.Forums;

namespace JESUSFORUMS.Models.Post
{
    public class PostListingModel
    {
        public ForumsListing Forum { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorId { get; set; }
        public string DatedPosted { get; set; }

       // public int ForumId { get; set; }
        //public string ForumName { get; set; }
       // public string ForumImageUrl { get; set; }

        public int RepliesCount { get; set; }
    }
}
