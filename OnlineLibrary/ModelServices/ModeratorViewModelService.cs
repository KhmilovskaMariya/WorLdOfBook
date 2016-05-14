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
            return Mapper.Map<IEnumerable<ApplicationUser>, List<ReaderModeratorViewModel>>(_userRepository.Set.Where(u => u.IsAuthor == false));
        }
    }
}
