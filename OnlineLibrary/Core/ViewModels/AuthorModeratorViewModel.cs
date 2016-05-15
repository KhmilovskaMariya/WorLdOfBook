using Core.Models;
using System.Collections.Generic;

namespace Core.ViewModels
{
    public class AuthorModeratorViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsBanned { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Book> Books { get; set; }
    }
}
