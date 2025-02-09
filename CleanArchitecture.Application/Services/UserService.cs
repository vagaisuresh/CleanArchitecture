﻿using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Parameters;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;

namespace CleanArchitecture.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _unitOfWork.UserRepository.GetUsersAsync();
        }

        public async Task<IEnumerable<User>> GetUsersPagingAsync(UserParameters userParameters)
        {
            return await _unitOfWork.UserRepository.GetUsersPagingAsync(userParameters.PageNumber, userParameters.PageSize);
        }

        public async Task<User> GetUserByIdAsync(short id)
        {
            return await _unitOfWork.UserRepository.GetUserByIdAsync(id);
        }
    }
}