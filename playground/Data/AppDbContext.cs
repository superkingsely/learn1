using System;

namespace playground.Data;
using Microsoft.EntityFrameworkCore;
using playground.Entity;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
}
