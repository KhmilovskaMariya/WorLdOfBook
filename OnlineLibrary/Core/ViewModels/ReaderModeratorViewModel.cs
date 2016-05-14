using Core.Models;
using System.Collections.Generic;

namespace Core.ViewModels
{
    public class ReaderModeratorViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
