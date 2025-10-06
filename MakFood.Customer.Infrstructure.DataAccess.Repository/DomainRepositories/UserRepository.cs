﻿using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MakFood.Customer.Infrstructure.DataAccess.Repository.DomainRepositories
{

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            var target = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (target == null) throw new Exception("The member you are looking for probebly dosent exist.");
            return target;
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            var target = await _context.Users.FirstOrDefaultAsync(x => x.Contactinfo.PhoneNumber == phoneNumber);
            if (target == null) throw new Exception("The member you are looking for probebly dosent exist.");
            return target;
        }

        public async Task<bool> IsUserExistByPhoneNumber(string phoneNumber)
        {
            var target = await _context.Users.FirstOrDefaultAsync(x => x.Contactinfo.PhoneNumber == phoneNumber);
            if (target == null) return false;
            else return true;

        }

        


    }
}
