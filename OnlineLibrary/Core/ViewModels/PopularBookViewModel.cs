using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class PopularBookViewModel
    {
        public int Id { get; set; }
        public File Image { get; set; }
        public string Decription { get; set; }
        public string Title { get; set; }
    }
}
