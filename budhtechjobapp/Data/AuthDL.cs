using budhtechjobapp.DbConfigures;
using budhtechjobapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Security.Principal;
using System.Xml;
using System;

namespace budhtechjobapp.Data
{
    public class AuthDL : IAuthDL
    {
        public readonly IConfiguration _Configuration;
        public readonly MyDbContext _dbContext;
        public AuthDL(IConfiguration configuration, MyDbContext dbContext)
        {
            _Configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<SignInResponse> SignInAsync(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            response.IsSuccess = false; 
            try
            {
                // 1. Validate the user's credentials (e.g., username and password)
                var user = await _dbContext.SignupRequests
                    .Where(u => u.UserName == request.Username && u.Password == request.Password)
                    .FirstOrDefaultAsync();

                if (user != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Login successful";
                }
                else
                {
                    response.Message = "Invalid credentials";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<SignupResponse> SignupAsync(SignupRequest request)
        {
            SignupResponse response = new SignupResponse();
            response.IsSuccess = true;
            response.Message = "Successfull";
            try
            {
                if (!request.Password.Equals(request.ConformPassword))
                {
                    response.IsSuccess = false;
                    response.Message = "Password Not matched";
                }
                else
                {
                    // Create a new instance of SignupRequest and populate it with data
                    var user = new SignupRequest
                    {
                        UserName = request.UserName,
                        Password = request.Password,
                        ConformPassword=request.ConformPassword,
                        Role = request.Role
                    };

                    // Add the user to the database
                    _dbContext.SignupRequests.Add(user);
                     await _dbContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                // Log or inspect the exception for details
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    Console.WriteLine(innerException.Message);
                    innerException = innerException.InnerException;
                }

            }

            return response;
        }
    }
}
