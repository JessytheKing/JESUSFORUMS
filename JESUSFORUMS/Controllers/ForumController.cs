using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JESUSFORUMS.EntitiesModel;
using JESUSFORUMS.Forums.Data;
using JESUSFORUMS.Models.Forums;
using Microsoft.AspNetCore.Mvc;

namespace JESUSFORUMS.Controllers
{
    public class ForumController : ControllerBase
    {
        private readonly IForum _forumService;
        public readonly IPost _postService; 
        public ForumController(IForum forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.Id,
                    Name = forum.Title,
                    Description = forum.Description

                });
            var model = new ForumIndex
            {
                ForumList = forums
            };
           
            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            var post = _postServices.GetFilteredPost(id)
            var postListing = 
        }
    }
}