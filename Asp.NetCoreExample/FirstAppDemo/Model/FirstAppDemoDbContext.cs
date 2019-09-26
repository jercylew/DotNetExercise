using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAppDemo.Model
{
    public class FirstAppDemoDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public FirstAppDemoDbContext(DbContextOptions<FirstAppDemoDbContext> options)
      : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
        //}
    }
}
