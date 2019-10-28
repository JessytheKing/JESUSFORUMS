using System.Collections.Generic;
using System.Threading.Tasks;
using JESUSFORUMS.EntitiesModel;

namespace JESUSFORUMS.Forums.Data
{
    public interface IPost
    {
        Post GetByID(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(string searchQuery);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);
        Task AddReply(PostReply reply); 

    }
}
