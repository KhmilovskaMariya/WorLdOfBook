using Core.Common;
using Core.Models;
using Data;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IDbContext _dbContext;

        public UserService(IRepository<ApplicationUser> userRepository, IDbContext dbContext)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return _userRepository.Set.ToList();
        }

        public void DeleteUser(string userId)
        {
            _userRepository.Delete(_userRepository.GetById(userId));
        }

        public ApplicationUser GetUser(string userId)
        {
            return _userRepository.GetById(userId); ;
        }

        public void ChangeStatus(string userId)
        {
            var user = _userRepository.GetById(userId);
            user.Status = UserStatus.None;
            _userRepository.Update(user);
        }
    }
}
