﻿using MakFood.Customer.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MakFood.Customer.Infrstructure.DataAccess.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository Users { get; }
        public UnitOfWork(ApplicationDbContext context, IUserRepository users)
        {
            _context = context;
            Users = users;
        }

        public async Task<int> SaveChange(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
