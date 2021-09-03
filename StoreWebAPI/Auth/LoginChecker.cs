using StoreWebAPI.Models.Service;
using System.Collections.Generic;

namespace StoreWebAPI.Auth
{
    public class LoginChecker
    {
        private List<Person> people = new List<Person>()
        {
            new Person() { Login = "1", Password = "1", Role = "admin"},
            new Person() { Login = "2", Password = "2", Role = "user"}
        };

        private readonly string login;
        private readonly string password;

        public LoginChecker(string login, string password)
        {
            (this.login, this.password) = (login, password);
        }

        public Person GetPerson()
        {
            return people.Find(p => p.Login == login && p.Password == password);
        }
    }
}
