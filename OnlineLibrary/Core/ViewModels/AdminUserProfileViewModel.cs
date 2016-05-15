using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class AdminUserProfileViewModel
    {
        public File Avatar { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
