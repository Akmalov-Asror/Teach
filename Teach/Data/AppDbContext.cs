using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teach.Entities;

namespace Teach.Data;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider services) : base(options)
    {
        this.Services = services;
    }

    public IServiceProvider Services { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<Meals> Meals { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Teachers> Teachers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration<IdentityRole>(new RoleConfiguration(Services));
    }
}