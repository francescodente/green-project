﻿using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Shared.Utils;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class AdminService : AbstractService, IAdminService
    {
        public AdminService(IRequestSession request)
            : base(request)
        {
        }

        public async Task SetUserEnabledState(int userId, bool enabled)
        {
            User user = await this.Data
                .Users
                .SingleOptionalAsync(s => s.UserId == userId)
                .Map(s => s.OrElseThrow(() => NotFoundException.UserWithId(userId)));

            user.IsEnabled = enabled;
            await this.Data.SaveChangesAsync();
        }
    }
}
