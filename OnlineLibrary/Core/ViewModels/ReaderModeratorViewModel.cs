using Core.Common;
using Core.Models;
using System.Collections.Generic;

namespace Core.ViewModels
{
    public class ReaderModeratorViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsBanned { get; set; }
    }
}
