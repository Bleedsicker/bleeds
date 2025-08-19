using Domain;

namespace DataAccess.Repository;

public interface IUserRepository
{
    List<User> GetUsers();

    void AddUser(User user);
}