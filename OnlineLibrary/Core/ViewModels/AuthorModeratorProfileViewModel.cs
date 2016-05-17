using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class AuthorModeratorProfileViewModel
    {
        public List<Book> Books { get; set; }
        public List<Comment> Comments { get; set; }
        public bool IsBanned { get; set; }
        public virtual File Avatar { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
