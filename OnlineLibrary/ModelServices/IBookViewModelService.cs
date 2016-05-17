using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelServices
{
    public interface IBookViewModelService
    {
        void AddBook(AddBookViewModel model);
        List<AuthorBookViewModel> GetAllAuthorsBook(string userId);
        List<ModeratorBookViewModel> GetAllBooksForModerators();
        void AcceptDeclineBook(int id, bool isAccepted);
        List<PopularBookViewModel> GetMostPopularBooks(int count);
        BookViewModel GetBook(int id);
        void RateBook(int id, int rateMark);
        ModeratorBookPreviewViewModel GetBookForModerator(int id);
        List<SearchBookViewModel> SearchBook(string query);
    }
}
