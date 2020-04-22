﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Database;
using APICore.Models;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;

namespace APICore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionProvider _context;
        public UserRepository(DbConnectionProvider ctx)
        {
            _context = ctx;
        }
        public void Add(User user)
        {
            _context.User.Add(user);            
            _context.SaveChanges();
        }

        public User Find(long id)
        {
            return _context.User.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public void Remove(long id)
        {
            var entity = _context.User.First(p => p.Id == id);
            _context.User.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public bool Login(string userName, string password) {
            var result = _context.User
                        .Where(u => u.UserName == userName)
                        .Where(u => u.Password == password).Any();

            return result;
        }
    }
}
