using InternetSystem.DBModels;
using InternetSystem.Models;

namespace InternetSystem.Repository
{
    public class UserRepository
    {
        public List<User> GetUsers()
        {
            var ctx = new InternetsysContext();
            var usersFound = ctx.Users.ToList();
            return usersFound;
        }

        public User? GetUser(int id)
        {
            var ctx = new InternetsysContext();
            var userFound = ctx.Users.Where(x => x.Userid == id).FirstOrDefault();
            
            return userFound;
        }

        public User createUser(User user)
        {
            var ctx = new InternetsysContext();
            ctx.Users.Add(user);
            return user;
        }
    }
}
