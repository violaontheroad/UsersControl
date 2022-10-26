using Test.Data;
using Test.Models;

namespace UsersControl.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        this._context = context;
    }
    public User SearchByEmail(string email)
    {
        return _context.Users.FirstOrDefault(x => x.Email == email); 
    }
}