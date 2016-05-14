using Core.Common;
using System.Collections.Generic;

namespace Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public BookStatus Status { get; set; }
        public string Edition { get; set; }
        public int YearOfPublication { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }
    }
}
