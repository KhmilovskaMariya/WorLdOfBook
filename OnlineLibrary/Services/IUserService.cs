using Core.Models;
using System.Collections.Generic;

namespace Services
{
    public interface IUserService
    {
        List<ApplicationUser> GetAllUsers();
    }
}
