using CodeFirstEFInApp.NetCoreDemo.Models;

namespace CodeFirstEFInApp.NetCoreDemo.Repositories
{
    public class PostRepository : IPost
    {
        private readonly EventContext context;

        public PostRepository(EventContext context)
        {
            this.context = context;
        }
        public void DeletePost(int postid)
        {
            Post postToBeDeleted=context.Posts.Find(postid);
            context.Posts.Remove(postToBeDeleted);
        }

        public Post GetPostByID(int postid)
        {
            return context.Posts.Find(postid);
        }

        public List<Post> GetPosts()
        {
            return context.Posts.ToList();
        }

        public void InsertPost(Post post)
        {
            context.Posts.Add(post);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            context.Update(post);
        }
    }
}
