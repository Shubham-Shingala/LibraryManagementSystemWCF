using Library_Management.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library_Management
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("LibConString")
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}