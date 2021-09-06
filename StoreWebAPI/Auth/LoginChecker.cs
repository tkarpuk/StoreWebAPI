using StoreWebAPI.Models.Service;
using System.Collections.Generic;

namespace StoreWebAPI.Auth
{
    public class LoginChecker
    {
        private readonly List<Person> _people = new List<Person>()
        {
            new Person() { Login = "1", Password = "1", Role = "admin"},
            new Person() { Login = "2", Password = "2", Role = "user"}
        };

        private readonly string _login;
        private readonly string _password;

        public LoginChecker(string login, string password)
        {
            (_login, _password) = (login, password);
        }

        public Person GetPerson()
        {
            return _people.Find(p => (p.Login == _login) && (p.Password == _password));
        }
    }
}
