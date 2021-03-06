﻿using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelServices
{
    public interface IUserViewModelService
    {
        UserProfileViewModel GetUser(string userId);
        AdminUserProfileViewModel GetUserForAdmin(string userId);
        ReaderModeratorProfileViewModel GetReaderForModerator(string userId);
        AuthorModeratorProfileViewModel GetAuthorForModerator(string userId);
        void EditAuthorProfile(UserProfileViewModel model);
    }
}
