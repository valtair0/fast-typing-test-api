
using Application.Entities;
using Application.Entities.Common;
using Application.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Contexts
{
    public class FastTypingTestDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public FastTypingTestDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TypingExam> TypingExam { get; set;}
        public DbSet<TypingResult> TypingTest { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Language> Languages { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //  ChangeTracker yeni eklenen veriyi yakalamak için kullanılır.

            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var item in entries)
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreateDate = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }

            }

            return await base.SaveChangesAsync(cancellationToken);
        }

       



    }
}
