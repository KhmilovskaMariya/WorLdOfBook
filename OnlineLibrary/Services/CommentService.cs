using Core.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentService(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void DeleteComment(int id)
        {
            var comment = _commentRepository.GetById(id);
            comment.Book.Comments.Remove(comment);
            comment.User.Comments.Remove(comment);
            _commentRepository.Delete(comment);
        }
    }
}
