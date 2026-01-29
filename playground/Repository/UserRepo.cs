using System;
using playground.Data;
using playground.Entity;

namespace playground.Repository;

public class UserRepo: IUserRepo
{
    private readonly AppDbContext _context;

    public UserRepo(AppDbContext context)
    {
        _context = context;
    }

    public  void CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public Entity.User? GetUserById(Guid id)
    {
        return _context.Users.Find(id);
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void DeleteUser(Guid id)
    {
        var user = GetUserById(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}