using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Parameters;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;

namespace CleanArchitecture.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _logger;

        public UserService(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _unitOfWork.UserRepository.GetUsersAsync();
        }

        public async Task<IEnumerable<User>> GetUsersPagingAsync(UserParameters userParameters)
        {
            return await _unitOfWork.UserRepository.GetUsersPagingAsync(userParameters.PageNumber, userParameters.PageSize);
        }

        public async Task<User?> GetUserAsync(short id)
        {
            return await _unitOfWork.UserRepository.GetUserAsync(id);
        }

        public async Task<User> CreateAsync(User user)
        {
            try
            {
                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.SaveAsync();

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while saving user in CreateAsync service method: {ex}");
                throw new InvalidOperationException($"An error occurred when saving the user: {ex.Message}");
            }
        }

        public async Task UpdateAsync(short id, User user)
        {
            var existingUser = await _unitOfWork.UserRepository.GetUserByIdAsync(id);

            if (existingUser == null)
                throw new InvalidOperationException("User not found.");

            existingUser.FullName = user.FullName;
            existingUser.EmailAddress = user.EmailAddress;
            existingUser.RoleId = user.RoleId;
            existingUser.MobileNumber = user.MobileNumber;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.ProfilePicture = user.ProfilePicture;
            existingUser.IsActive = user.IsActive;

            try
            {
                _unitOfWork.UserRepository.Update(existingUser);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating user in UpdateAsync service method: {ex}");
                throw new InvalidOperationException($"An error occurred when updating the user: {ex.Message}");
            }
        }

        public async Task DeleteAsync(short id)
        {
            var existingUser = await _unitOfWork.UserRepository.GetUserByIdAsync(id);

            if (existingUser == null)
                throw new InvalidOperationException("User not found.");

            try
            {
                _unitOfWork.UserRepository.Remove(existingUser);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting user in DeleteAsync service method: {ex}");
                throw new Exception($"An error occurred when saving the role: {ex.Message}");
            }
        }
    }
}