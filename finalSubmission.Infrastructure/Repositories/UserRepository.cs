﻿using finalSubmission.Core.Domain.Entities;
using finalSubmission.Core.Domain.RepositoryContracts;
using finalSubmission.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace finalSubmission.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskOrderDbContext _dbContext;

        public UserRepository(TaskOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Creates a new user in the database if the username does not already exist.
        /// </summary>
        /// <param name="user">The user entity to be created.</param>
        /// <returns>The created user entity, or null if the username already exists.</returns>
        public async Task<User?> CreateUser(User user)
        {

            // Check if the user already exists in the database
            var existingUser = await _dbContext.AllUsersTable
                .FirstOrDefaultAsync(u => u.UserName == user.UserName);

            if (existingUser != null)
            {
                return null; // User already exists
            }

            // Add and save the new user
            await _dbContext.AllUsersTable.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user; // Return the successfully created user

        }


        /// <summary>
        /// Deletes a user from the database by username if the user exists.
        /// </summary>
        /// <param name="UserName">The username of the user to delete.</param>
        /// <returns>The deleted user entity if successful; null if the user does not exist.</returns>
        public async Task<User?> DeleteUser(string UserName)
        {
            var user = await _dbContext.AllUsersTable.FirstOrDefaultAsync(u => u.UserName == UserName);

            if (user is not null)
            {
                // Remove the user if found
                _dbContext.AllUsersTable.Remove(user);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return user; // Return the deleted user entity
            }

            return null; // Return null if the user does not exist
        }

        public async Task<List<User>> GetAllAnUsers()
        {
            return await _dbContext.AllUsersTable.ToListAsync();
        }

        /// <summary>
        /// Checks if a user with the given username already exists in the database.
        /// </summary>
        /// <param name="UserName">The username to check for existence.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        public async Task<bool> UserExists(string UserName)
        {
            return await _dbContext.AllUsersTable.AnyAsync(u => u.UserName == UserName);
        }
    }
}