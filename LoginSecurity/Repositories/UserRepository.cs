﻿using LoginSecurity.Data;
using LoginSecurity.JwtToken;
using LoginSecurity.Models.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginSecurity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankManagementDbContext bankManagementDbContext;

        ITokenManager _tokenManager = new TokenManager();

        public UserRepository(BankManagementDbContext bankManagementDbContext)
        {
            this.bankManagementDbContext = bankManagementDbContext;
        }

        public async Task<int> ValidateUserCredAsync(string userName, string password)
        {
            UserDetail user = bankManagementDbContext.UserDetails?.Where(x => 
                                            x.UserName == userName &&
                                            x.Password == password)
                                            .FirstOrDefault();

            if (user != null)
            {
                string userToken = user.Token;
                bool valid = _tokenManager.ValidateToken(userToken);

                if (valid)
                    return user.Role;

                else
                {
                    string token = _tokenManager.GenerateJsonWebToken(user.UserName);
                    user.Token = token;
                    await bankManagementDbContext.SaveChangesAsync();
                    return user.Role;
                }
            }
            else
                return 2;
        }
        public async Task<UserDetail> GetUserAsync(string userName)
        {
           return await bankManagementDbContext.UserDetails?.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
