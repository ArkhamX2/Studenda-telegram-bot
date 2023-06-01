using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using model;

public class ApplicationContext : DbContext
{
    public DbSet<ChatUser> Users => Set<ChatUser>();
    public ApplicationContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=D:\\2 курс\\gi\\sqlite\\test.db");
    }
}