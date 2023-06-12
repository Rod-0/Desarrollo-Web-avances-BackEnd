using Infraestructure.Models;
using LearningCenter.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context;

public class LearningCenterDBContext : DbContext
{
    public LearningCenterDBContext()
    {

    }

    public LearningCenterDBContext(DbContextOptions<LearningCenterDBContext> options) : base(options) { }

    public DbSet<Tutorial> Tutorials { get; set; }

    public DbSet<Category> Categories{ get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));  
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=70162057;Database=LearningDB;", serverVersion);
        }
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p => p.Id); //PK
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Description).IsRequired().HasMaxLength(60);


        builder.Entity<Tutorial>().ToTable("Tutorials");
        builder.Entity<Tutorial>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(c => c.Username).IsRequired().HasMaxLength(60);
        builder.Entity<User>().Property(c => c.Password).IsRequired().HasMaxLength(120);
        builder.Entity<User>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);
    }


}

