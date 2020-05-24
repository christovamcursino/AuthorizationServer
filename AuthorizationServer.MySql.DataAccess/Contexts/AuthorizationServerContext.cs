using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorizationServer.MySql.DataAccess.Contexts
{
    public class AuthorizationServerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=localhost;Database=dbauthenticator;User=oauth;Password=oauth;", mySqlOptions => mySqlOptions
                    .ServerVersion(new Version(8, 0, 19), ServerType.MySql));
        }
    }
}
