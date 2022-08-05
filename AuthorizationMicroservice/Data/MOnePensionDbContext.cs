using AuthorizationMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Data
{
    public class MOnePensionDbContext :DbContext
    {
        public MOnePensionDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LoginModel> loginModels { get; set; }
       

    }
}

