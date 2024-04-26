using Application.Entities;
using Application.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class FastTypingTestDbContext : DbContext
    {
        public FastTypingTestDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TypingExam> TypingExam { get; set;}
        public DbSet<TypingResult> TypingTest { get; set; }

        public DbSet<Category> Categories { get; set; }


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
                    case EntityState.Modified:
                        item.Entity.UpdateDate = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }

            }

            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}
