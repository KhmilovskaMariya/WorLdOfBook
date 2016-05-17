using AutoMapper;
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
    public class UserViewModelService : IUserViewModelService
    {
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IDbContext _dbContext;

        public UserViewModelService(IRepository<ApplicationUser> userRepository, IDbContext dbContext)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
        }

        public UserProfileViewModel GetUser(string userId)
        {
            return Mapper.Map<ApplicationUser, UserProfileViewModel>(_userRepository.GetById(userId));
        }

        public AdminUserProfileViewModel GetUserForAdmin(string userId)
        {
            return Mapper.Map<ApplicationUser, AdminUserProfileViewModel>(_userRepository.GetById(userId));
        }

        public ReaderModeratorProfileViewModel GetReaderForModerator(string userId)
        {
            return Mapper.Map<ApplicationUser, ReaderModeratorProfileViewModel>(_userRepository.GetById(userId));
        }

        public AuthorModeratorProfileViewModel GetAuthorForModerator(string userId)
        {
            return Mapper.Map<ApplicationUser, AuthorModeratorProfileViewModel>(_userRepository.GetById(userId));
        }
    }
}
