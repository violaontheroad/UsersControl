using Test.Models;

namespace UsersControl.Repository;

public interface IUserRepository
{
    User SearchByEmail(string email);
}