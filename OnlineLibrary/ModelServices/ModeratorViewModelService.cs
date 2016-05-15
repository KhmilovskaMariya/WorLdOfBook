using AutoMapper;
using Core.Common;
using Core.Models;
using Core.ViewModels;
using Data;
using System.Collections.Generic;
using System.Linq;

namespace ModelServices
{
    public class ModeratorViewModelService : IModeratorViewModelService
    {
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IDbContext _dbContext;

        public ModeratorViewModelService(IRepository<ApplicationUser> userRepository, IDbContext dbContext)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
        }

        public List<ReaderModeratorViewModel> GetAllReaders()
        {
            return Mapper.Map<IEnumerable<ApplicationUser>, List<ReaderModeratorViewModel>>(_userRepository.Set.Where(u => u.Status == UserStatus.Reader));
        }

        public List<AuthorModeratorViewModel> GetAllAuthors()
        {
            return Mapper.Map<IEnumerable<ApplicationUser>, List<AuthorModeratorViewModel>>(_userRepository.Set.Where(u => u.Status == UserStatus.Author));
        }

        public void BanUnbanUser(string userId, bool isBan)
        {
            var user = _userRepository.GetById(userId);
            user.IsBanned = isBan;
            _dbContext.SaveChanges();
        }
    }
}
