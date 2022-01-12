using DomainLayer.Models;
using RepositoryLayer.Context;
using RepositoryLayer.Interfaces;


namespace RepositoryLayer.RepositoryPattern
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(PostContext context) : base(context)
        {
        }
    }
}
