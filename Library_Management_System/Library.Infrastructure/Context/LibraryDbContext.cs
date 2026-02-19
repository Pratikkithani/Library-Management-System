using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Library.Infrastructure.Configuration;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Context
{
    public class LibraryDbContext : DbContext
    {
        readonly ILoggedInUserService _loggedInUserService;
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options,ILoggedInUserService loggedInUserService) : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            //modelBuilder.ApplyConfiguration(new LoanConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.CreatedById = _loggedInUserService.UserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedOn = DateTime.Now;
                        entry.Entity.UpdatedById = _loggedInUserService.UserId;
                        break;


                }
                    
            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
