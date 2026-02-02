using Domain;

namespace DataAccess.Repository;

public class UserRepository : IUserRepository
{
    private readonly WebDevDBcontext _dbContext;

    public UserRepository(WebDevDBcontext dBContext)
    {
        _dbContext = dBContext;
    }

    public User AddUser(User user)
    {
        var newUser = _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        return newUser.Entity;
    }

    public List<User> GetUsers()
    {
        return _dbContext.Users.ToList();
    }
}
