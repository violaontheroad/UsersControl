using Test.Models;

namespace UsersControl.Helper;

public interface IUserSession
{
    void addUserSession(User user);

    void removeUserSession();

    User SearchUserSession();
    
}