using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APICore.Model;

namespace APICore.Database
{
    public class DbConnectionProvider : DbContext
    {
        public DbConnectionProvider(DbContextOptions<DbConnectionProvider> options)
              : base(options)
        { }

        public DbSet<User> User { get; set; }
    }
}
