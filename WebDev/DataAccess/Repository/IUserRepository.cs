using Domain;

namespace DataAccess.Repository;
public interface IUserRepository
{
    List<User> GetUsers();
    User AddUser(User user);
}