using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore; 
using JESUSFORUMS.EntitiesModel;
using JESUSFORUMS.Forums.Data;
using Microsoft.Extensions.Options;

namespace ForumsServices
{
    public class ForumsServices : IForum
    {
        private readonly ApplicationDbContext _context;
        private readonly IPost _postservice;

        // Uses entity framework to interact with our data. 
        public ForumsServices(ApplicationDbContext context, IPost postService)
        {
            _context = context;
            _postService = postService;
        }

        public async Task Create(Forums forum)
        {
            _context.Add(forum);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var forum = GetById(id);
            _context.Remove(forum);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ApplicationUser> GetActiveUsers(int forumId)
        {
            var posts = GetById(forumId).Posts;

            if (posts == null || posts.Any())
            {
                return new List<ApplicationUser>();
            }

            return _postServices.GetAllUsers(posts);
        }

        public IEnumerable<Forums> GetAll()
        {
            return _context.Forums
                .Include(forums => forums.Posts);

        }

        public Forums GetByID(int id)
        {
            var forum = _context.Forums
                .Where(f => f.Id == id)
                .Include(f => f.Posts)
                .ThenInclude(f => f.User)
                .Include(f => f.Post)
                .ThenInclude(f => f.Replies)
                .ThenInclude(f => f.User)
                .Include(f => f.Posts)
                .ThenInclude(p => p.Forum)
                .FirstOrDefault();

            if (forum.Post == null)
            {
                forum.Post = new List<Post>();
            }

            return forum;
        }

        public Post GetLatestPost(int forumId)
        {
            var posts = GetByID(forumId).Posts;

            if (posts != null)
            {
                return GetByID(forumId).Posts
                    .OrderByDescending(post => post.Created)
                    .FirstOrDefault();
            }

            return new Post();
        }

        public bool HasRecentPost(int id)
        {
            const int hoursAgo = 12;
            var window = DateTime.Now.AddHours(-hoursAgo);
            return GetByID(id).Posts.Any(post => post.Created >= window);
        }

        public async Task Add(Forums forum)
        {
            _context.Add(forum);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<Post> GetFilterPosts(string seachQuery)
        {
            return _postService.GetFilteredPosts(searchQuery);
        }

        public async Task SetFourmImage(int id, Uri uri)
        {
            var forum = GetById(id);
            forum.ImaageUrl = uri.AbsoluteUri;
            _context.Update(forum);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Post> GetFilterPosts(int forumId, string seachQuery)
        {
            if (forumId == 0)
            {
                return _postService.GetFilterPosts(seachQuery);
            }

            var forum = GetByID(forumId);
            return string.IsNullOrEmpty(searchQuery)
                ? forum.Posts
                : forum.Posts.Where(post => post.Title.Contains(seachQuery) || post.Content.Contains(seachQuery));

        }

        public async Task UpdateForumDescription(int id, string description)
        {
            var forum = GetByID(id);
            forum.Description = description;

            _context.Update(forum);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateForumsTitle(int id, string title)
        {
            var forum = GetByID(id);
            forum.Title = title;

            _context.Update(forum);
            await _context.SaveChangesAsync();

        }

        //public IEnumerable<Forums> GetAll();
        //{
        //    return _context.Forums.Include(forums => forums.Posts);
        //}

    }
}


