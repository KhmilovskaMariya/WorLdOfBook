using Core.Models;
using System.Collections.Generic;

namespace Services
{
    public interface IUserService
    {
        List<ApplicationUser> GetAllUsers();
        void DeleteUser(string userId);
        ApplicationUser GetUser(string userId);
        void ChangeStatus(string userid);
    }
}
