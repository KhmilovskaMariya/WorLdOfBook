using Core.ViewModels;
using System.Collections.Generic;

namespace ModelServices
{
    public interface IModeratorViewModelService
    {
        List<ReaderModeratorViewModel> GetAllReaders();
        List<AuthorModeratorViewModel> GetAllAuthors();
        void BanUnbanUser(string userId, bool isBan);
    }
}
