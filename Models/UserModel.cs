using System.Collections.Generic;
using UsersControl.Services;

namespace Test.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }

        // public void PasswordHash()
        // {
        //     Password = Password.GenerateHash();
        // }

        // public bool ValidPassword(string password)
        // {
        //     return Password == password.GenerateHash();
        // }
    }
}
