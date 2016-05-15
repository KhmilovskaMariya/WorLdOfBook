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
    public class CommentViewModelService : ICommentViewModelService
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentViewModelService(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<ModeratorCommentViewModel> GetAllCommentsSortedByDateForLastWeek()
        {
            var date = DateTime.Now.AddDays(-7);
            return Mapper.Map<IEnumerable<Comment>, List<ModeratorCommentViewModel>>(_commentRepository.Set.Where(c => c.PostTime > date).OrderByDescending(c => c.PostTime));
        }
    }
}
