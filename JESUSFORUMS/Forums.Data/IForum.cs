using JESUSFORUMS.EntitiesModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JESUSFORUMS.Forums.Data
{
    public interface IForum

    {
       EntitiesModel.Forums GetById(int id);
       IEnumerable<EntitiesModel.Forums> GetAll();
       IEnumerable<ApplicationUser> GetApplicationUsers();

       Task Create(EntitiesModel.Forums forum);
       Task Delete(int id);
       Task UpdateForumsTitle(int id, string newTitle);
       Task UpdateForumDescription(int forumId, string newDescription);



    }
}
