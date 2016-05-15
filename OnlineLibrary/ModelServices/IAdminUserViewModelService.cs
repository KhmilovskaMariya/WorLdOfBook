﻿using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelServices
{
    public interface IAdminUserViewModelService
    {
        List<AdminUserViewModel> GetAllAdminUsers();
        void GiveRightsToUser(string userId);
    }
}
