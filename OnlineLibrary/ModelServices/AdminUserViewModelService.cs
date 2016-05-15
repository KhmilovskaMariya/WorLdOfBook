using AutoMapper;
using Core.Common;
using Core.Models;
using Core.ViewModels;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelServices
{
    public class AdminUserViewModelService : IAdminUserViewModelService
    {
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IDbContext _dbContext;

        public AdminUserViewModelService(IRepository<ApplicationUser> userRepository, IDbContext dbContext)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
        }

        public List<AdminUserViewModel> GetAllAdminUsers()
        {
            return Mapper.Map<IEnumerable<ApplicationUser>, List<AdminUserViewModel>>(_userRepository.Set.Where(u => u.Status != UserStatus.None));
        }

        public void GiveRightsToUser(string userId)
        {
            var user = _userRepository.GetById(userId);
            user.Status = UserStatus.None;
            _dbContext.SaveChanges();            
        }
    }
}
