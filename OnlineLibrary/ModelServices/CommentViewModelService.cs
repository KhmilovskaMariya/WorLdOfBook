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
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IRepository<Book> _bookRepository;

        public CommentViewModelService(IRepository<Comment> commentRepository,
            IRepository<ApplicationUser> userRepository, IRepository<Book> bookRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public List<ModeratorCommentViewModel> GetAllCommentsSortedByDateForLastWeek()
        {
            var date = DateTime.Now.AddDays(-7);
            return Mapper.Map<IEnumerable<Comment>, List<ModeratorCommentViewModel>>(_commentRepository.Set.Where(c => c.PostTime > date).OrderByDescending(c => c.PostTime));
        }

        public void CommentBook(CommentViewModel model)
        {
            var comment = Mapper.Map<CommentViewModel, Comment>(model);
            var user = _userRepository.GetById(model.UserId);
            var book = _bookRepository.GetById(model.BookId);
            comment.Book = book;
            comment.User = user;
            comment.PostTime = DateTime.Now;
            if(user.Comments == null)
            {
                user.Comments = new List<Comment>();
            }
            if(book.Comments == null)
            {
                book.Comments = new List<Comment>();
            }
            user.Comments.Add(comment);
            book.Comments.Add(comment);
            _commentRepository.Insert(comment);
        }
    }
}
