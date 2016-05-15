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
    public class BookViewModelService : IBookViewModelService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IDbContext _dbContext;
        private readonly IRepository<File> _fileRepository;

        public BookViewModelService(IRepository<Book> bookRepository, IRepository<ApplicationUser> userRepository,
            IDbContext dbContext, IRepository<File> fileRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _dbContext = dbContext;
            _fileRepository = fileRepository;
        }

        public void AddBook(AddBookViewModel model)
        {
            var book = Mapper.Map<AddBookViewModel, Book>(model);
            var author = _userRepository.GetById(model.AuthorId);
            book.Users = new List<ApplicationUser>();
            book.Users.Add(author);
            author.Books.Add(book);
            _bookRepository.Insert(Mapper.Map<AddBookViewModel, Book>(model));
        }

        public List<AuthorBookViewModel> GetAllAuthorsBook(string userId)
        {
            return Mapper.Map<List<Book>, List<AuthorBookViewModel>>(_userRepository.GetById(userId).Books);
        }

        public List<ModeratorBookViewModel> GetAllBooksForModerators()
        {
            return Mapper.Map<IEnumerable<Book>, List<ModeratorBookViewModel>>(_bookRepository.Set.Where(b => b.Status == BookStatus.New));
        }

        public void AcceptDeclineBook(int id, bool isAccepted)
        {
            var book = _bookRepository.GetById(id);
            book.Status = isAccepted ? BookStatus.Confirmed : BookStatus.Declined;
            _bookRepository.Update(book);
        }

        public List<PopularBookViewModel> GetMostPopularBooks(int count)
        {
            return Mapper.Map<IEnumerable<Book>, List<PopularBookViewModel>>(_bookRepository.Set.Where(b => b.Status == BookStatus.Confirmed).OrderBy(b => b.Rating).Take(count));
        }

        public BookViewModel GetBook(int id)
        {
            return Mapper.Map<Book, BookViewModel>(_bookRepository.GetById(id));
        }

        public void RateBook(int id, int rateMark)
        {
            var book = _bookRepository.GetById(id);
            book.RatingMarks.Add(rateMark);
            book.Rating = (int)book.RatingMarks.Average();
            _bookRepository.Update(book);
        }
    }
}
