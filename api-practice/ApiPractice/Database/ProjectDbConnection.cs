using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;

public class ProjectDbConnection : DbContext
{
    public ProjectDbConnection(DbContextOptions<ProjectDbConnection> options) : base(options)
    {
    }

    public DbSet<Product> ProductDb { get; set; }

}