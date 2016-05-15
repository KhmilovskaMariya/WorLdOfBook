using Core.Common;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class AddBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Edition { get; set; }
        public int YearOfPublication { get; set; }
        public virtual string AuthorId { get; set; }
        public virtual File Image { get; set; }
        public string Description { get; set; }
    }
}
