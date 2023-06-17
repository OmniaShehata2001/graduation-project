using graduation_project.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graduation_project.DBContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {

        }



        public DbSet<User> User{ get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
    }
}
