using Microsoft.EntityFrameworkCore;

namespace EverPostWebApi.Commons.Dbcontext
{
    public class EverPostContext : DbContext
    {
        public EverPostContext(DbContextOptions<EverPostContext> options) : base(options)
        { } 

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<RelPostCategorie> RelPostCategories { get; set; }
        




    }
}
