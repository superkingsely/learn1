using System;

namespace playground.Repository;

public interface IUserRepo
{
    void CreateUser(Entity.User user);
    Entity.User? GetUserById(Guid id);
    void UpdateUser(Entity.User user);
    void DeleteUser(Guid id);
}
