using Domain;

namespace DataAccess.Repository;

internal class UserRepository : IUserRepository
{
    private readonly WebDevDBcontext _dbContext;

    public UserRepository(WebDevDBcontext dBContext)
    {
        _dbContext = dBContext;
    }

    public void AddUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public List<User> GetUsers()
    {
        return _dbContext.Users.ToList();
    }
}
