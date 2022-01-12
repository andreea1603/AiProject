using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Post> Post { get; set; }

        Task<int> SaveChangesAsync();
    }
}
