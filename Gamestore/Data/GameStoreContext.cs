using System;
using Gamestore.Models;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> opt):DbContext(opt)
{
    // public DbSet<Game> Games{get;set;}

    public DbSet<Game> Games=>Set<Game>();
    public DbSet<Genre> Genres=>Set<Genre>();

}
