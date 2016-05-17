using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class ModeratorBookPreviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Edition { get; set; }
        public int YearOfPublication { get; set; }
        public ApplicationUser Author { get; set; }
        public virtual File Image { get; set; }
    }
}
