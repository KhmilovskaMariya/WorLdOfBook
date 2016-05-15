using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class ModeratorCommentViewModel
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Book Book { get; set; }
        public string Text { get; set; }
        public DateTime PostTime { get; set; }
    }
}
