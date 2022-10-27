using System;
using System.Collections.Generic;
using System.Text;
using DLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DLL.DBContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,int,IdentityUserClaim<int>,AppUserRole
        ,IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>> 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CustomerBalance>().Property(p => p.RowVersion).IsConcurrencyToken();
        //}

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<CustomerBalance> CustomerBalances { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
    }
}
