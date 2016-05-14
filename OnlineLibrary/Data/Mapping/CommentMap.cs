using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Text).IsRequired();
            Property(t => t.PostTime).IsRequired();
            HasRequired(s => s.User)
                .WithMany(s => s.Comments)
                .HasForeignKey(s => s.UserId);
            HasRequired(s => s.Book)
                .WithMany(s => s.Comments)
                .HasForeignKey(s => s.BookId);
            ToTable("Comments");
        }
    }
}
