using CodingCha.Entities;
using CodingCha.Database;

namespace CodingCha.Services
{
    public class UserService : IUserService
    {
        private readonly MyContext Context;
        public UserService(MyContext context)
        {
            Context = context;
        }

        public void CreateUser(User user)
        {
            try
            {
                Context.Users.Add(user);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteUser(int userid)
        {

            User user  = Context.Users.Find(userid);
            if (user != null)
            {
                Context.Users.Remove(user);
                Context.SaveChanges();
            }
        }

        public void EditUser(User user)
        {
            Context.Users.Update(user);
            Context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            var result = Context.Users.ToList();
            return result;
        }

        public User GetUserById(int userid)
        {
            return Context.Users.Find(userid);
        }

        public User ValidateUser(string email, string password)
        {
            return Context.Users.SingleOrDefault(u=>u.Email == email && u.Password == password);
        }
    }
}
