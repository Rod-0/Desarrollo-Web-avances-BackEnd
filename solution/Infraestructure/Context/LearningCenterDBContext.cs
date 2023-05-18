using Infraestructure.Models;
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

    public DbSet<Tutorial> Tutorial { get; set; }

    public DbSet<Category> Category{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));  
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=70162057;Database=learningdb;", serverVersion);
        }
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p => p.Id); //PK
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.name).IsRequired().HasMaxLength(60);


        builder.Entity<Tutorial>().ToTable("Tutorials");
        builder.Entity<Tutorial>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

    }


}

