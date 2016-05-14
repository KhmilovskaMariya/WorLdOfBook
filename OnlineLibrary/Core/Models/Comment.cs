using System;

namespace Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Book Book { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Text { get; set; }
        public DateTime PostTime { get; set; }
    }
}
