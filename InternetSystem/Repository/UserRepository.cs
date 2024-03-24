using InternetSystem.DBModels;
using InternetSystem.Models;

namespace InternetSystem.Repository
{
    public class UserRepository
    {
        private InternetsysContext _Context;
        public UserRepository(InternetsysContext ctx)
        {
            _Context = ctx;
        }
        public List<User> GetUsers()
        {
            var usersFound = _Context.Users.ToList();
            return usersFound;
        }

        public User? GetUser(int id)
        {
            var userFound = _Context.Users.Where(x => x.Userid == id).FirstOrDefault();
            
            return userFound;
        }

        public User createUser(User user)
        {
            _Context.Users.Add(user);
            return user;
        }
    }
}
