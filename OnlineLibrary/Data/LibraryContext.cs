using Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Data
{
    public class LibraryContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<File> Files { get; set; }

        public LibraryContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static LibraryContext Create()
        {
            return new LibraryContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();          
        }
    }
}
