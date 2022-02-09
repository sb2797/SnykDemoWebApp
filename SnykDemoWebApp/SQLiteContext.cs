using SnykDemoWebApp.Controllers;
using Microsoft.EntityFrameworkCore;

namespace SnykDemoWebApp;

public class SQLiteContext : DbContext
{
    public DbSet<Vulnerability> Vulnerabilities { get; set; }
    
    public string DbPath { get; }

    public SQLiteContext()
    {
        DbPath = System.IO.Path.Join(Directory.GetCurrentDirectory(), "VulDb.sqlite");
    }
    
    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}