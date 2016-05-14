using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Title).IsRequired();
            Property(t => t.Language).IsRequired();
            Property(t => t.Status).IsRequired();
            Property(t => t.Edition).IsRequired();
            Property(t => t.YearOfPublication).IsRequired();
            HasMany<ApplicationUser>(t => t.Users)
                .WithMany(t => t.Books)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("BookId");
                    cs.ToTable("UsersBooks");
                });
            ToTable("Books");
        }
    }
}
